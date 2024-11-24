using System;

namespace Practical7
{
    public class Player
    {
        private static Player uniqueInstance = null;

        private readonly Command[] commands = new Command[12];
        private Command lastCommand;

        private int hp;
        private int maxHp;
        private int mp;
        private int maxMp;
        private int magicPower;

        // Private constructor for Singleton
        private Player(int maxHp, int maxMp, int magicPower)
        {
            this.maxHp = maxHp;
            this.maxMp = maxMp;
            this.magicPower = magicPower;
            this.hp = maxHp;
            this.mp = maxMp;

            for (int i = 0; i < commands.Length; i++)
            {
                commands[i] = new NoCommand();
            }
            lastCommand = new NoCommand();
        }

        // Singleton instance retrieval
        public static Player getInstance(int maxHp, int maxMp, int magicPower)
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new Player(maxHp, maxMp, magicPower);
            }
            return uniqueInstance;
        }

        // Setter for commands
        public void setCommand(Command command, int slot)
        {
            commands[slot] = command;
        }

        // Execute a command
        public void hotkeyPushed(int slot)
        {
            commands[slot].execute();
            lastCommand = commands[slot];
        }

        // Undo the last executed command
        public void undoKeyPushed()
        {
            lastCommand.undo();
        }

        // Getters for private fields
        public int getHp()
        {
            return hp;
        }

        public int getMaxHp()
        {
            return maxHp;
        }

        public int getMp()
        {
            return mp;
        }

        public int getMaxMp()
        {
            return maxMp;
        }

        public int getMagicPower()
        {
            return magicPower;
        }
        public void setHp(int value)
        {
            hp = Math.Max(0, Math.Min(maxHp, value)); // Ensure HP is within valid bounds
        }

        public void setMp(int value)
        {
            mp = Math.Max(0, Math.Min(maxMp, value)); // Ensure MP is within valid bounds
        }

        // Helper functions for HP and MP management
        public void heal(int amount)
        {
            hp = Math.Min(maxHp, hp + amount);
        }

        public void takeDamage(int amount)
        {
            hp = Math.Max(0, hp - amount);
        }

        public void useMana(int amount)
        {
            mp = Math.Max(0, mp - amount);
        }

        public void restoreMana(int amount)
        {
            mp = Math.Min(maxMp, mp + amount);
        }
    }
}
