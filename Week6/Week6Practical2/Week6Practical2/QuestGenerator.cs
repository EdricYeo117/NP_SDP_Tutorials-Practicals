using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6Practical2
{
    // QuestGenerator class
    public class QuestGenerator
    {
        private QuestFactory _factory;

        public QuestGenerator(QuestFactory factory)
        {
            _factory = factory;
        }

        public void LaunchQuest(string type)
        {
            Quest quest = _factory.createQuest(type);
            Monster monster = _factory.createMonster(type);
            int number = _factory.getNumber(type);
            int timeLimit = _factory.getTimeLimit(type);

            quest.prepare(monster, number, timeLimit);
            quest.calculateReward();
            Console.WriteLine(quest.getDescription());
        }
    }

    class RivendellQuestGenerator : QuestGenerator
    {
        public RivendellQuestGenerator() : base(new RivendellQuestFactory()) { }
    }

    // MordorQuestGenerator implementation
    class MordorQuestGenerator : QuestGenerator
    {
        public MordorQuestGenerator() : base(new MordorQuestFactory()) { }
    }
}
