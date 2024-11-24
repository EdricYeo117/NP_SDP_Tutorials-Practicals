using System;

namespace Practical7
{
    public abstract class Spell
    {
        private Player player;
        private string name;
        private int cost;

        // Constructor to initialize Spell
        public Spell(Player player, string name, int cost)
        {
            this.player = player;
            this.name = name;
            this.cost = cost;
        }

        // Getter for player
        public Player getPlayer()
        {
            return player;
        }

        // Getter for name
        public string getName()
        {
            return name;
        }

        // Getter for cost
        public int getCost()
        {
            return cost;
        }

        // Abstract method for effect
        public abstract int effect();
    }

    public class FireballSpell : Spell
    {
        // Constructor to initialize FireballSpell
        public FireballSpell(Player player, int cost) : base(player, "Fireball", cost) { }

        // Override effect
        public override int effect()
        {
            return getPlayer().getMagicPower() * 2; 
        }
    }

    public class HealingSpell : Spell
    {
        // Constructor to initialize HealingSpell
        public HealingSpell(Player player, int cost) : base(player, "Healing", cost) { }

        // Override effect
        public override int effect()
        {
            return getPlayer().getMagicPower();
        }
    }
}
