using System;
using System.Collections;
using System.Collections.Generic;


public class Item
{
    public string Name { get; set; }
    public string ItemType { get; set; }
    public int RequiredLevel { get; set; }

    public Item(string name, string itemType, int requiredLevel)
    {
        Name = name;
        ItemType = itemType;
        RequiredLevel = requiredLevel;
    }
}

public class Character
{
    public string Name { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }

    private static Dictionary<string, List<string>> classItemCompatibility = new Dictionary<string, List<string>>()
    {
        { "Mage", new List<string> { "Spell Tome", "Magic Robe", "Mana Crystal" } },
        { "Ranger", new List<string> { "Bow", "Repeater", "Ranger Armor" } },
        { "Melee Warrior", new List<string> { "Broadsword", "Flail", "Heavy Armor", "Shield" } }
    };

    public Character(string name, string charClass, int level)
    {
        Name = name;
        Class = charClass;
        Level = level;
    }

    public bool EquippableItem(Item item)
    {
        // Ensure the character has the required level to use the item.
        if (Level < item.RequiredLevel)
        {
            return false; // Character level is too low.
        }

        // Ensure the item type matches the character's class compatibility.
        if (classItemCompatibility.ContainsKey(Class) && classItemCompatibility[Class].Contains(item.ItemType))
        {
            return true; // The item is compatible with the character's class.
        }

        return false; // The character's class cannot use this item.
    }
}

public class Shop
{
    private List<Item> shopItems;

    public Shop()
    {
        shopItems = new List<Item>();
    }
    
    public void AddItem(Item item)
    {
        shopItems.Add(item);
    }

    public IEnumerable<Item> CreateUsuableItemIterator (Character character)
    {
        foreach (Item item in shopItems)
        {
            if (character.EquippableItem(item))
            {
                yield return item;
            }
        }
    }   
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create some items
        Item spellTome = new Item("Spell Tome of Fire", "Spell Tome", 3);
        Item magicRobe = new Item("Enchanted Magic Robe", "Magic Robe", 1);
        Item broadsword = new Item("Fiery Great Broadsword", "Broadsword", 4);
        Item bow = new Item("Hellfire Bow", "Bow", 2);
        Item manaCrystal = new Item("Mana Crystal", "Mana Crystal", 5);
        Item shield = new Item("Cobalt Shield", "Shield", 3);

        // Create a shop and add items
        Shop shop = new Shop();
        shop.AddItem(spellTome);
        shop.AddItem(magicRobe);
        shop.AddItem(broadsword);
        shop.AddItem(bow);
        shop.AddItem(manaCrystal);
        shop.AddItem(shield);

        // Create a character
        Character character = new Character("Celeste", "Mage", 4);

        // List all usable items for the character
        Console.WriteLine($"Usable items for {character.Name}:");
        foreach (Item item in shop.CreateUsuableItemIterator(character))
        {
            Console.WriteLine($"- {item.Name}");
        }
    }
}