using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Practical2
{
    public abstract class Quest
    {
        protected int reward;
        protected int timeLimit;
        protected int number;
        protected Monster monster;

        public Quest() { }

        public abstract void prepare(Monster monster, int number, int timeLimit);

        public void calculateReward()
        {
            reward = monster.Difficulty * number - timeLimit;
        }

        public virtual string getDescription()
        {
            return $"Kill {number} {monster} monsters in {timeLimit} days for {reward} gold pieces.";
        }
    }

    public class VillageQuest : Quest
    {
        public override void prepare(Monster monster, int number, int timeLimit)
        {
            this.monster = monster;
            this.number = number;
            this.timeLimit = timeLimit;
        }
        public override string getDescription()
        {
            return base.getDescription();
        }
    }

    public class CityQuest : Quest
    {
        public override void prepare(Monster monster, int number, int timeLimit)
        {
            this.monster = monster;
            this.number = number;
            this.timeLimit = timeLimit;
        }

        public override string getDescription()
        {
            return base.getDescription();
        }
    }
}
