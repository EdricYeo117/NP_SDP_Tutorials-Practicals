using System;

abstract class CharacterCreator
{
    public void createCharacter()
    {
        chooseRace();
        assignAbilities();
        if (isSpellcaster())
        {
            assignSpells();
        }
        finalizeCharacter();
    }
    
    protected void chooseRace()
    {
        Console.WriteLine("Choosing race...");
    }

    protected void finalizeCharacter()
    {
        Console.WriteLine("Character creation complete.");
    }

    protected abstract void assignAbilities();
    protected abstract bool isSpellcaster();
    protected virtual void assignSpells() { }
}

class WarriorCreator : CharacterCreator
{
    protected override void assignAbilities()
    {
        Console.WriteLine("Assigning warrior abilities: Block, Shield Bash");
    }

    protected override bool isSpellcaster()
    {
        return false;
    }
}

class WizardCreator : CharacterCreator
{
    protected override void assignAbilities()
    {
        Console.WriteLine("Assigning wizard abilities: Focus, Quick Cast");
    }

    protected override bool isSpellcaster()
    {
        return true;
    }

    protected override void assignSpells()
    {
        Console.WriteLine("Assigning spells: Fireball, Slow, Magic Missile");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating Warrior:");
        CharacterCreator warriorCreator = new WarriorCreator();
        warriorCreator.createCharacter();

        Console.WriteLine("\nCreating Wizard:");
        CharacterCreator wizardCreator = new WizardCreator();
        wizardCreator.createCharacter();
    }
}