using System;

namespace Practical7
{
    public interface Command
    {
        void execute();
        void undo();
    }

    public class NoCommand : Command
    {
        public void execute()
        {
            Console.WriteLine("No command set!");
        }

        public void undo()
        {
            Console.WriteLine("No command set!");
        }
    }

    public class DrinkHealingPotionCommand : Command
    {
        private readonly HealingPotion healingPotion;

        public DrinkHealingPotionCommand(HealingPotion healingPotion)
        {
            this.healingPotion = healingPotion;
        }

        public void execute()
        {
            int healed = healingPotion.drink();
            healingPotion.getPlayer().heal(healed); 
            Console.WriteLine($"Player is healed for {healed} HP.");
        }

        public void undo()
        {
            healingPotion.getPlayer().takeDamage(10); 
            healingPotion.incrementDoses(); 
            Console.WriteLine("Undoing drinking healing potion for 10 HP.");
        }
    }

    public class DrinkManaPotionCommand : Command
    {
        private readonly ManaPotion manaPotion;

        public DrinkManaPotionCommand(ManaPotion manaPotion)
        {
            this.manaPotion = manaPotion;
        }

        public void execute()
        {
            int restored = manaPotion.drink();
            manaPotion.getPlayer().restoreMana(restored); 
            Console.WriteLine($"Player restores {restored} MP.");
        }

        public void undo()
        {
            manaPotion.getPlayer().useMana(5); 
            manaPotion.incrementDoses(); 
            Console.WriteLine("Undoing drinking mana potion for 5 MP.");
        }
    }

    public class CastFireballCommand : Command
    {
        private readonly FireballSpell spell;

        public CastFireballCommand(FireballSpell spell)
        {
            this.spell = spell;
        }

        public void execute()
        {
            Player player = spell.getPlayer(); 
            if (player.getMp() >= spell.getCost()) 
            {
                int damage = spell.effect();
                player.useMana(spell.getCost()); 
                Console.WriteLine($"Player casts FIREBALL for {damage} damage!");
            }
            else
            {
                Console.WriteLine("You do not have enough MP to cast FIREBALL.");
            }
        }

        public void undo()
        {
            spell.getPlayer().restoreMana(spell.getCost()); 
            Console.WriteLine($"Undoing casting FIREBALL for {spell.getCost()} MP.");
        }
    }

    public class CastHealingCommand : Command
    {
        private readonly HealingSpell spell;

        public CastHealingCommand(HealingSpell spell)
        {
            this.spell = spell;
        }

        public void execute()
        {
            Player player = spell.getPlayer();
            if (player.getMp() >= spell.getCost()) 
            {
                int healed = spell.effect();
                player.useMana(spell.getCost()); 
                player.heal(healed);
                Console.WriteLine($"Player casts HEALING and heals for {healed} HP.");
            }
            else
            {
                Console.WriteLine("You do not have enough MP to cast HEALING.");
            }
        }

        public void undo()
        {
            Player player = spell.getPlayer(); 
            player.takeDamage(player.getMagicPower()); 
            player.restoreMana(spell.getCost()); 
            Console.WriteLine("Undoing casting HEALING spell.");
        }
    }
}
