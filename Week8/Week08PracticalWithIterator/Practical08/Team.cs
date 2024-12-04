using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical08
{
    public class Team: GameEntity
    {
        private string name; 
        private List<GameEntity> gameEntities;

        public string Name
        {
            get
            {
                return name;
            }
        }
        public Team(string name)
        {
            this.name = name;
            gameEntities = new List<GameEntity>();
        }
        public override string getDescription()
        {
            return $"Team {Name}";
        }
        public override void add(GameEntity ge)
        {
            gameEntities.Add(ge);
            Console.WriteLine($"{ge.getDescription()} joins {Name}!");
        }
        
        public override void remove(GameEntity ge)
        {
            gameEntities.Remove(ge);
            Console.WriteLine($"{ge.getDescription()} leaves {Name}!");
        }
        public override GameEntity getChild(int index)
        {
            return gameEntities[index];
        }
        public override void print()
        {
            Console.WriteLine(Name.ToUpper() + ":");
            TeamIterator iter = createIterator();
            while (iter.hasNext())
            {
                Console.Write($"    ");
                GameEntity ge = (GameEntity)iter.next();
                ge.print();
            }
        }
        public TeamIterator createIterator()
        {
            return new TeamIterator(gameEntities);
        }
    }
}
