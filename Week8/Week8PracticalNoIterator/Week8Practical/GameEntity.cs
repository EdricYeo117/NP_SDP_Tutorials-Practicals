using System;
using System.Collections.Generic;

namespace Week8Practical
{
    public abstract class GameEntity
    {
        public string Name { get; set; }
        public virtual void add(GameEntity entity)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        public virtual void remove(GameEntity entity)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        public virtual GameEntity getChild(int index)
        {
            throw new InvalidOperationException("Invalid operation");
        }

        public virtual string getDescription()
        {
            throw new InvalidOperationException("Invalid operation");
        }

        public virtual void print()
        {
            throw new InvalidOperationException("Invalid operation");
        }
    }

    public class PC : GameEntity
    {
        private string Profession { get; set; }

        public PC(string name, string profession)
        {
            Profession = profession;
            Name = name;
        }

        public override string getDescription()
        {
            return $"{Name} the {Profession}";
        }

        public override void print()
        {
            Console.WriteLine(getDescription());
        }
    }

    public class NPC : GameEntity
    {
        private string Profession { get; set; }

        public NPC(string name, string profession)
        {
            Profession = profession;
            Name = name;
        }

        public override string getDescription()
        {
            return $"{Name} the {Profession}";
        }

        public override void print()
        {
            Console.WriteLine(getDescription());
        }
    }

    public class Team : GameEntity
    {
        private List<GameEntity> teamEntities;

        public Team(string name)
        {
            Name = name;
            teamEntities = new List<GameEntity>();
        }

        public override void add(GameEntity entity)
        {
            if (entity != null)
            {
                teamEntities.Add(entity);
                Console.WriteLine($"{entity.getDescription()} joins {Name}!");
            }
            else
            {
                throw new ArgumentNullException(nameof(entity), "Cannot add a null entity");
            }
        }

        public override void remove(GameEntity entity)
        {
            if (entity != null && teamEntities.Contains(entity))
            {
                teamEntities.Remove(entity);
                Console.WriteLine($"{entity.getDescription()} leaves {Name}!");
            }
            else
            {
                throw new InvalidOperationException("Entity not found in the team.");
            }
        }

        public override GameEntity getChild(int index)
        {
            if (index >= 0 && index < teamEntities.Count)
            {
                return teamEntities[index];
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
        }

        // Properly override getDescription to return a meaningful description
        public override string getDescription()
        {
            return $"Team {Name}";
        }

        public override void print()
        {
            Console.WriteLine($"{Name}:");
            foreach (var entity in teamEntities)
            {
                entity.print();
            }
        }

        public List<GameEntity> GetEntities()
        {
            return teamEntities;
        }
    }

    public class Arena
    {
        private string Name { get; set; }
        private List<GameEntity> arenaTeams;

        // Default constructor
        public Arena()
        {
            Name = "Arena";
            arenaTeams = new List<GameEntity>();
        }

        // Constructor that takes a GameEntity (a team) and adds its entities to the arena
        public Arena(GameEntity initialTeam)
        {
            Name = "Arena";
            arenaTeams = new List<GameEntity>();

            if (initialTeam is Team team)
            {
                foreach (var entity in team.GetEntities())
                {
                    arenaTeams.Add(entity); // Directly adding to avoid duplicate join messages
                }
            }
            else
            {
                throw new ArgumentException("Initial team must be of type Team");
            }
        }

        // Add entity to the arena
        public void addEntity(GameEntity team)
        {
            if (team != null)
            {
                arenaTeams.Add(team);
                Console.WriteLine($"Team {team.Name} joins {Name}!");
            }
            else
            {
                throw new ArgumentNullException(nameof(team), "Cannot add a null team");
            }
        }

        // Remove entity from the arena
        public void removeEntity(GameEntity team)
        {
            if (team != null && arenaTeams.Contains(team))
            {
                arenaTeams.Remove(team);
                Console.WriteLine($"Team {team.Name} leaves {Name}!");
            }
            else
            {
                throw new InvalidOperationException("Team not found in the arena.");
            }
        }

        // Print the current state of the arena
        public void print()
        {
            Console.WriteLine($"{Name}:");
            foreach (var team in arenaTeams)
            {
                team.print();
            }
        }
    }
}