using System;

namespace Practical7
{
    public abstract class Potion
    {
        private Player player;
        private string name;
        private int doses;

        // Constructor to initialize the potion
        public Potion(Player player, string name, int doses)
        {
            this.player = player;
            this.name = name;
            this.doses = doses;
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

        // Getter for doses
        public int getDoses()
        {
            return doses;
        }

        // Public method to increment doses
        public void incrementDoses()
        {
            doses++;
        }

        // Public method to decrement doses (only if doses > 0)
        public bool decrementDoses()
        {
            if (doses > 0)
            {
                doses--;
                return true;
            }
            Console.WriteLine("The potion bottle is empty!");
            return false;
        }

        // Abstract method to be implemented by subclasses
        public abstract int drink();
    }

    public class HealingPotion : Potion
    {
        private int healAmount;

        // Constructor to initialize the healing potion
        public HealingPotion(Player player, int healAmount, int doses) : base(player, "Healing Potion", doses)
        {
            this.healAmount = healAmount;
        }

        // Override drink method
        public override int drink()
        {
            if (decrementDoses()) // Use decrementDoses() to safely modify doses
            {
                return healAmount;
            }
            return 0;
        }
    }

    public class ManaPotion : Potion
    {
        private int manaAmount;

        // Constructor to initialize the mana potion
        public ManaPotion(Player player, int manaAmount, int doses) : base(player, "Mana Potion", doses)
        {
            this.manaAmount = manaAmount;
        }

        // Override drink method
        public override int drink()
        {
            if (decrementDoses()) // Use decrementDoses() to safely modify doses
            {
                return manaAmount;
            }
            return 0;
        }
    }
}
