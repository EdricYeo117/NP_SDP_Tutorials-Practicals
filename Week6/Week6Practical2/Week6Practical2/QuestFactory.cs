using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Practical2
{
    public interface QuestFactory
    {
        Quest createQuest(string type);
        Monster createMonster(string type);
        int getNumber(string type);
        int getTimeLimit(string type);
    }

    public class RivendellQuestFactory : QuestFactory
    {
        public Quest createQuest(string type)
        {
            return type.ToLower() == "village" ? new VillageQuest() : new CityQuest();
        }

        public Monster createMonster(string type)
        {
            return type.ToLower() == "village" ? new Pixie() : new Thief();
        }

        public int getNumber(string type)
        {
            return type.ToLower() == "village" ? 3 : 3;
        }

        public int getTimeLimit(string type)
        {
            return 5;
        }
    }

    public class MordorQuestFactory : QuestFactory
    {
        public Quest createQuest(string type)
        {
            return type.ToLower() == "village" ? new VillageQuest() : new CityQuest();
        }

        public Monster createMonster(string type)
        {
            return type.ToLower() == "village" ? new GiantRat() : new Bandit();
        }

        public int getNumber(string type)
        {
            return type.ToLower() == "village" ? 5 : 5;
        }

        public int getTimeLimit(string type)
        {
            return 3;
        }
    }
}
