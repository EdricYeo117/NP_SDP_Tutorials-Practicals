using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical5
{
    public abstract class SuffixDecorator : Weapon
    {
        protected Weapon decoratedWeapon;

        public SuffixDecorator(Weapon weapon)
        {
            // Enforce the single suffix rule by checking if the weapon already has a suffix
            if (weapon is SuffixDecorator)
            {
                throw new InvalidOperationException("A weapon can only have one suffix.");
            }
            this.decoratedWeapon = weapon;
        }

        public virtual string getDescription()
        {
            return decoratedWeapon.getDescription();
        }

        public virtual int getDamage()
        {
            return decoratedWeapon.getDamage();
        }
    }

    public class Pain : SuffixDecorator
    {
        public Pain(Weapon weapon) : base(weapon) { }

        public override string getDescription()
        {
            return decoratedWeapon.getDescription() + " of Pain";
        }

        public override int getDamage()
        {
            return decoratedWeapon.getDamage() + 2;
        }
    }

    public class Justice : SuffixDecorator
    {
        public Justice(Weapon weapon) : base(weapon) { }

        public override string getDescription()
        {
            return decoratedWeapon.getDescription() + " of Justice";
        }

        public override int getDamage()
        {
            return decoratedWeapon.getDamage() + 4;
        }
    }

    public class Vengeance : SuffixDecorator
    {
        public Vengeance(Weapon weapon) : base(weapon) { }

        public override string getDescription()
        {
            return decoratedWeapon.getDescription() + " of Vengeance";
        }

        public override int getDamage()
        {
            return decoratedWeapon.getDamage() + 6;
        }
    }
}
