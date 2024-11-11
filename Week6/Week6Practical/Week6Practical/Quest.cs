using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week6Practical
{
    public abstract class Quest
    {
        protected int reward;
        protected int timeLimit;
        protected int number;
        protected Monster monster;

        public Quest(int number, int reward, int timeLimit, Monster monster)
        {
            this.number = number;
            this.reward = reward;
            this.timeLimit = timeLimit;
            this.monster = monster;
        }

        public virtual string getDescription()
        {
            return $"Quest {number} - Reward: {reward} gold pieces - Time Limit: {timeLimit} days";
        }
    }

    public class MordorVillageQuest : Quest
    {
        public MordorVillageQuest(Monster monster) : base(6, 10, 5, monster) { }

        public override string getDescription()
        {
            return $"Kill {number} {monster} monsters in {timeLimit} days for {reward} gold pieces.";
        }
    }

    public class MordorCityQuest : Quest
    {
        public MordorCityQuest(Monster monster) : base(4, 20, 7, monster) { }

        public override string getDescription()
        {
            return $"Kill {number} {monster} monsters in {timeLimit} days for {reward} gold pieces.";
        }
    }

    public class RivendellVillageQuest : Quest
    {
        public RivendellVillageQuest(Monster monster) : base(3, 8, 4, monster) { }

        public override string getDescription()
        {
            return $"Kill {number} {monster} monsters in {timeLimit} days for {reward} gold pieces.";
        }
    }

    public class RivendellCityQuest : Quest
    {
        public RivendellCityQuest(Monster monster) : base(2, 15, 6, monster) { }

        public override string getDescription()
        {
            return $"Kill {number} {monster} monsters in {timeLimit} days for {reward} gold pieces.";
        }
    }
}