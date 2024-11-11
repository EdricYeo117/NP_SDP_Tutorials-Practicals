using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Practical
{
    public class Monster
    {
        public string Name { get; set; }

        public Monster(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Pixie : Monster
    {
        public Pixie() : base("Pixie") { }
    }

    public class Thief : Monster
    {
        public Thief() : base("Thief") { }
    }

    public class GiantRat : Monster
    {
        public GiantRat() : base("Giant Rat") { }
    }

    public class Bandit : Monster
    {
        public Bandit() : base("Bandit") { }
    }
}