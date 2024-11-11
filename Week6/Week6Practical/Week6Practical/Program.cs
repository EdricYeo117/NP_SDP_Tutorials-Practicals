using System;
using System.Collections.Generic;

namespace Week6Practical
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestGenerator questGenerator = new RivendellQuestGenerator();
            questGenerator.launchQuest("village");
            questGenerator.launchQuest("city");

            questGenerator = new MordorQuestGenerator();
            questGenerator.launchQuest("village");
            questGenerator.launchQuest("city");
        }
    }
}
