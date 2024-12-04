using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical08
{
    public class NPC: GameEntity
    {
        private string name;
        private string profession;

        public NPC(string name, string profession)
        {
            this.name = name;
            this.profession = profession;
        }
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string Profession
        {
            get
            {
                return profession;
            }
        }
        public override string getDescription()
        {
            return $"{name} the {profession}";
        }

        public override void print()
        {

            Console.WriteLine(getDescription());
        }

    }
}
