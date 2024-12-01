using System;

namespace Practical7
{
    public abstract class Spell
    {
        private string name;
        private int cost;

        // Constructor to initialize Spell
        public Spell(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
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
        private Player Player;
        // Constructor to initialize FireballSpell
        public FireballSpell(Player player, int cost) : base("Fireball", cost) { Player = player; }

        public void setPlayer(Player player)
        {
            this.Player = player;
        }

        public Player getPlayer()
        {
            return Player;
        }
        // Override effect
        public override int effect()
        {
            return getPlayer().getMagicPower() * 2; 
        }
    }

    public class HealingSpell : Spell
    {
        private Player Player;
        // Constructor to initialize HealingSpell
        public HealingSpell(Player player, int cost) : base( "Healing", cost) { Player = player; }
        public void setPlayer(Player player)
        {
            this.Player = player;
        }

        public Player getPlayer()
        {
            return Player;
        }
        // Override effect
        public override int effect()
        {
            return getPlayer().getMagicPower();
        }
    }
}
