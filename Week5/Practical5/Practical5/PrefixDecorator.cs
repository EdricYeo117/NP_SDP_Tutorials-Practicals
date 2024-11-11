using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical5
{
    public abstract class PrefixDecorator : Weapon
    {
        protected Weapon decoratedWeapon;

        public PrefixDecorator(Weapon decoratedWeapon)
        {
            this.decoratedWeapon = decoratedWeapon;
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

    public class Burning : PrefixDecorator
    {
        public Burning(Weapon decoratedWeapon) : base(decoratedWeapon) { }

        public override string getDescription()
        {
            return "Burning " + decoratedWeapon.getDescription();
        }

        public override int getDamage()
        {
            return decoratedWeapon.getDamage() + 3;
        }
    }

    public class Icy : PrefixDecorator
    {
        public Icy(Weapon decoratedWeapon) : base(decoratedWeapon) { }

        public override string getDescription()
        {
            return "Icy " + decoratedWeapon.getDescription();
        }

        public override int getDamage()
        {
            return decoratedWeapon.getDamage() + 3;
        }
    }
    public class Blessed : PrefixDecorator
    {
        public Blessed(Weapon decoratedWeapon) : base(decoratedWeapon) { }

        public override string getDescription()
        {
            return "Blessed " + decoratedWeapon.getDescription();
        }

        public override int getDamage()
        {
            return decoratedWeapon.getDamage() + 3;
        }
    }
}
