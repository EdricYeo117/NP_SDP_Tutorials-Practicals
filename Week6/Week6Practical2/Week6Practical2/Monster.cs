using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Practical2
{
    public class Monster
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }

        public Monster(string name, int difficulty)
        {
            Name = name;
            Difficulty = difficulty;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Pixie : Monster
    {
        public Pixie() : base("Pixie", 3) { }
    }

    public class Thief : Monster
    {
        public Thief() : base("Thief", 8) { }
    }

    public class GiantRat : Monster
    {
        public GiantRat() : base("Giant Rat", 2) { }
    }

    public class Bandit : Monster
    {
        public Bandit() : base("Bandit", 5) { }
    }
}
