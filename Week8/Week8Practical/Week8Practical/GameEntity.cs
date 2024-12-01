using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

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
            return Name + " the " + Profession;
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
            return Name + " the " + Profession;
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
            teamEntities.Add(entity);
            Console.WriteLine($"{entity.Name} joins {Name}");
        }

        public override void remove(GameEntity entity)
        {
            teamEntities.Remove(entity);
            Console.WriteLine($"{entity.Name} leaves {Name}");
        }

        public override GameEntity getChild(int index)
        {
            return teamEntities[index];
        }

        public override void print()
        {
            Console.WriteLine($"{Name}:");
            foreach (var entity in teamEntities)
            {
                entity.print();
            }
        }
    }

    public class Arena : GameEntity
    {
        private GameEntity arenaTeams;
        public Arena(GameEntity teams)
        {
            Name = "Arena";
            arenaTeams = teams;
        }

        public override void add(GameEntity entity)
        {
            arenaTeams.add(entity);
            Console.WriteLine($"Team {entity.Name} joins {Name}");
        }

        public override void remove(GameEntity entity)
        {
            arenaTeams.add(entity);
            Console.WriteLine($"Team {entity.Name} leaves {Name}");
        }

        public override GameEntity getChild(int index)
        {
            return base.getChild(index);
        }

        public override void print()
        {
            Console.WriteLine($"{Name}:");
            arenaTeams.print();
        }
    }
}
