// See https://aka.ms/new-console-template for more information

using Week8Practical;

void Main()
{
    GameEntity hero1 = new PC("Warren", "Warrior");
    GameEntity hero2 = new PC("Wendy", "Wizard");
    GameEntity mob1 = new NPC("Oscar", "Orc");
    GameEntity mob2 = new NPC("Gary", "Goblin");

    GameEntity arenaTeams = new Team("Arena");

    GameEntity team1 = new Team("Awesome");
    team1.add(hero1);
    GameEntity team2 = new Team("Killers");
    team2.add(hero2);
    team2.add(mob1);
    GameEntity team3 = new Team("Lonely");
    team3.add(mob2);
    arenaTeams.add(team1);
    arenaTeams.add(team2);
    arenaTeams.add(team3);

    Arena arena = new Arena(arenaTeams);
    Console.WriteLine("--- Current Arena Teams ---");
    arena.print();
    Console.WriteLine("---------------------------\n");

    arena.remove(team2);
    team3.add(team2);
    Console.WriteLine("--- New Arena Teams ---");
    arena.print();
    Console.WriteLine("-----------------------");

}

Main();