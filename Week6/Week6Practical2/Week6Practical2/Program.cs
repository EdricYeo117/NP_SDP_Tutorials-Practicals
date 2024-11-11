// Main Program
using Week6Practical2;

class Program
{
    static void Main(string[] args)
    {
        QuestGenerator questGenerator = new RivendellQuestGenerator();
        questGenerator.LaunchQuest("village");
        questGenerator.LaunchQuest("city");

        questGenerator = new MordorQuestGenerator();
        questGenerator.LaunchQuest("village");
        questGenerator.LaunchQuest("city");
    }
}
