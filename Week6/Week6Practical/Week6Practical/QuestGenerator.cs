using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Practical
{
    public abstract class QuestGenerator
    {
        public Quest launchQuest(string type)
        {
            Quest quest = createQuest(type);
            if (quest != null)
            {
                Console.WriteLine(quest.getDescription());
            }
            return quest;
        }

        protected abstract Quest createQuest(string type);

        protected Monster GetRandomMonster(List<Monster> monsters)
        {
            Random random = new Random();
            int index = random.Next(monsters.Count);
            return monsters[index];
        }
    }

    public class MordorQuestGenerator : QuestGenerator
    {
        // Predefine what monsters are available in Mordor
        private List<Monster> monsters = new List<Monster>
        {
            new GiantRat(),
            new Bandit()
        };

        // Create Quest function
        protected override Quest createQuest(string type)
        {
            Monster randomMonster = GetRandomMonster(monsters);
            if (type.Equals("village", StringComparison.OrdinalIgnoreCase))
            {
                return new MordorVillageQuest(randomMonster);
            }
            else if (type.Equals("city", StringComparison.OrdinalIgnoreCase))
            {
                return new MordorCityQuest(randomMonster);
            }
            return null;
        }
    }

    public class RivendellQuestGenerator : QuestGenerator
    {
        // Predefined list of monster instances for Rivendell
        private List<Monster> monsters = new List<Monster>
        {
            new Pixie(),
            new Thief()
        };

        // Create quest for Rivendell based on the type (village or city)
        protected override Quest createQuest(string type)
        {
            Monster randomMonster = GetRandomMonster(monsters);
            if (type.Equals("village", StringComparison.OrdinalIgnoreCase))
            {
                return new RivendellVillageQuest(randomMonster);
            }
            else if (type.Equals("city", StringComparison.OrdinalIgnoreCase))
            {
                return new RivendellCityQuest(randomMonster);
            }
            return null;
        }
    }
}