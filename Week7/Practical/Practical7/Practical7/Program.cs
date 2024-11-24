using System;
using System.Collections.Generic;
using Practical7;


void main()
{
    // Create player with 50 max HP, 10 max MP and 8 magic power
    Player player = Player.getInstance(50, 10, 8);

    HealingPotion healing_potion = new HealingPotion(player, 10, 3);
    ManaPotion mana_potion = new ManaPotion(player, 5, 3);
    FireballSpell fireball_spell = new FireballSpell(player, 8);
    HealingSpell healing_spell = new HealingSpell(player, 3);

    Command drink_healing =
            new DrinkHealingPotionCommand(healing_potion);
    Command drink_mana = new DrinkManaPotionCommand(mana_potion);
    Command cast_fireball = new CastFireballCommand(fireball_spell);
    Command cast_healing = new CastHealingCommand(healing_spell);

    player.setCommand(drink_healing, 0);
    player.setCommand(drink_mana, 1);
    player.setCommand(cast_fireball, 2);
    player.setCommand(cast_healing, 3);

    player.setHp(25);
    player.setMp(3);
    Console.WriteLine($"Player has {player.getHp()}/{player.getMaxHp()} HP and {player.getMp()}/{player.getMaxMp()} MP.");

    player.hotkeyPushed(0); // healing potion
    player.hotkeyPushed(0); // healing potion
    player.undoKeyPushed(); // undo
    player.hotkeyPushed(0); // healing potion
    player.hotkeyPushed(0); // healing potion
    player.hotkeyPushed(0); // healing potion

    player.hotkeyPushed(1); // mana potion
    player.hotkeyPushed(1); // mana potion

    player.hotkeyPushed(2); // fireball
    player.hotkeyPushed(2); // fireball
    player.hotkeyPushed(1); // mana potion
    player.hotkeyPushed(2); // fireball
    player.hotkeyPushed(3); // healing spell
    player.undoKeyPushed(); // undo
}

main();