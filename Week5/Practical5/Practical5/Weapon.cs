using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical5
{
    public interface Weapon
    {
        string getDescription();
        int getDamage();
    }

    public class Dagger : Weapon
    {
        public string getDescription()
        {
            return "Dagger";
        }

        public int getDamage()
        {
            return 4;
        }
    }

    public class Sword : Weapon
    {
        public string getDescription()
        {
            return "Sword";
        }

        public int getDamage()
        {
            return 5;
        }
    }

    public class Mace : Weapon
    {
        public string getDescription()
        {
            return "Mace";
        }

        public int getDamage()
        {
            return 5;
        }
    }
}
