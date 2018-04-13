using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace arena_fighter_3.cs
{
    class Rounds
    {
       
        public Rounds(Characters character, List<string> rounds)
        {
            Random random = new Random(); // The dice rolled for combat
            int pD6;
            int eD6;
            int gold = character.Gold;// Saving the gold in new score command.
            int score = character.score;
            Console.WriteLine($"Opponents : {character.Opponent}\nStats = Health: {character.EHealth} Damage: {character.EDamage} Strenght: {character.EStrenght}");
            foreach (var round in rounds)//stat incase per round played for opponent
            {
                character.EHealth += 5;
                character.EDamage +=  1;
                character.EStrenght += 1;
            }

            Console.WriteLine($"\n{character.Opponent} picking gear to fight you with.\n");
            OpponentWeapon(character);// Making Opponent and weapon selection.
            OpponentArmor(character);// Making Opponent and armor selection.
            int ehealth = character.EHealth; // Saving the health to new health command.
            int phealth = character.PHealth;
            
            Console.WriteLine($"Opponents : {character.Opponent}\nStats = Health: {character.EHealth} Damage: {character.EDamage} Strenght: {character.EStrenght}");
            Console.WriteLine("\nPush any key to start battle");
            Console.ReadKey(true);
            Console.Clear();
            
            while (phealth > 0 && ehealth > 0) // Loop to 1 fighter get 0 or below health
            {
                pD6 = random.Next(1, 7); //The combat dice
                eD6 = random.Next(1, 7); 
                int proll = pD6 + character.PStrenght; //The Dice + strenght determinal who strike first.
                int eroll = eD6 + character.EStrenght;
                if (proll > eroll)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{character.Player} rolled the D6: {pD6} = {proll} {character.Opponent} rolled the D6: {eD6} = {eroll}");
                    ehealth -= character.PDamage;
                    Console.WriteLine($"\n{character.Player} dealt {character.PDamage} damage to {character.Opponent}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (eroll >proll) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{character.Opponent} rolled the D6: {eD6} = {eroll} {character.Player} rolled the D6: {pD6} = {proll}");
                    phealth -= character.EDamage;
                    Console.WriteLine($"\n{character.Opponent} dealt {character.EDamage} damage to {character.Player}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{character.Player} Weapon clash into {character.Opponent} weapon no damage dealt.\nThe weapons take damage both lose 1 damage.");
                    character.PDamage -= 1;
                    character.EDamage -= 1;
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine($"\nChampion : {character.Player}\nStats = Health: {phealth} Damage: {character.PDamage} Strenght: {character.PStrenght}");
                Console.WriteLine($"\nOpponents : {character.Opponent}\nStats = Health: {ehealth} Damage: {character.EDamage} Strenght: {character.EStrenght}");
                Console.WriteLine("\nPush any key to continue fighting");
                Console.ReadKey(true);
                Console.Clear();
            }
            if (ehealth <= 0)//If Opponent get to 0 health.
            {
                Console.WriteLine($"\nWinner is {character.Player}.");
                character.PHealth = phealth; // Updating the new health back to original command.
                rounds.Add($"\nChampion {character.Player} fought and won over {character.Opponent}.");
                character.Gold = gold + 1;// Adding 1 point to the score.
                character.score = score + 1;
                Reward(character); // Random reward pulled from reward table below.
            }
            if (phealth <= 0) // If player reach 0 health.
            {
                Console.WriteLine($"\nYou lost to {character.Opponent} that has health {ehealth} left\nPush any key to see final statistic.");
                character.EHealth = ehealth;
                character.PHealth = phealth;
                rounds.Add($"\nOpponent {character.Opponent} fought and won over {character.Player}.");
                Console.ReadKey();
                Console.Clear();
            }
            

        }

        public void OpponentWeapon(Characters character) // Oppponent random selected  weapon and title.
        {
            int weapon = D4();//Call method for user input from below to help select a weapon.

            switch (weapon)
            {
                case 1:
                    character.Opponent += " Defender";
                    character.EHealth += D2();
                    character.EDamage += D2();
                    character.EStrenght += D6();
                    break;

                case 2:
                    character.Opponent += " Gladiator";
                    character.EDamage += D6();
                    character.EStrenght += D4();
                    break;

                case 3:
                    character.Opponent += " Warrior";
                    character.EDamage += D8();
                    character.EStrenght += D2();
                    break;

                case 4:
                    character.Opponent += " Boss";
                    character.EHealth += D4() + 1;
                    character.EDamage += D10() + 1;
                    character.EStrenght += D4() + 1;
                    break;

                case 5:
                    character.Opponent += " Reaper";
                    character.EHealth += D10() + 100;
                    character.EDamage += D10() + 100;
                    character.EStrenght += D10() + 50;
                    break;


            }
        }
        public void OpponentArmor(Characters character)// Method for picking a armor for character.
        {

            int armor = D3(); //Call method for user input from below to help select a armor.

                switch (armor)
                {
                    case 1:
                        character.EHealth += D8();
                        character.EStrenght += D2();
                        character.Opponent += " Heavy";
                        break;

                    case 2:
                        character.EHealth += D6();
                        character.EStrenght += D4();
                        character.Opponent += " Medium";
                        break;

                    case 3:
                        character.EHealth += D2();
                        character.EStrenght += D8();
                        character.Opponent += " Light";
                        break;
                   
                }
            
        }
        //10 random rewards you can get at victory in each round.
        static void Reward(Characters characters)
        {
            int input = D10();

            switch (input)
            {
                case 1:
                    Console.WriteLine("Reward granted for this battle: Rest + 5 Health");
                    characters.PHealth += 5;
                    break;
                case 2:
                    Console.WriteLine("Reward granted for this battle: Band aid + 10 Health");
                    characters.PHealth += 10;
                    break;
                case 3:
                    Console.WriteLine("Reward granted for this battle: Basic weapon maintance +1 Damage");
                    characters.PDamage += 1;
                    break;
                case 4:
                    Console.WriteLine("Reward granted for this battle: Basic training + 1 Strenght");
                    characters.PStrenght += 1;
                    break;
                case 5:
                    Console.WriteLine("Reward granted for this battle: Gold + 5");
                    characters.Gold += 5;
                    break;
                case 6:
                    Console.WriteLine("Reward granted for this battle: Field doctor + 20 Health");
                    characters.PHealth += 20;
                    break;
                case 7:
                    Console.WriteLine("Reward granted for this battle: Advanced weapon maintane + 2 Damage");
                    characters.PDamage += 2;
                    break;
                case 8:
                    Console.WriteLine("Reward granted for this battle: Advanced training + 2 Strenght");
                    characters.PStrenght += 2;
                    break;
                case 9:
                    Console.WriteLine("Reward granted for this battle: Treasure Gold + 10");
                    characters.Gold += 10;
                    break;
                case 10:
                    Console.WriteLine("Reward granted for this Battle: Camp + 10 health, + 1 Damage, + 1 Strenght, + 10 gold");
                    characters.PHealth += 10;
                    characters.PDamage += 1;
                    characters.PStrenght += 1;
                    characters.Gold += 10;

                    break;
                case 11:
                    Console.WriteLine("Reward granted for this battle: God mode status = + 500 H, +100 D, + 100 S, + 200 gold");
                    characters.Player += " God mode";
                    characters.PHealth += 500;
                    characters.PDamage += 100;
                    characters.PStrenght += 100;
                    characters.Gold += 200;
                    break;
            }
        }
        // The random dices 
        static Random _roll = new Random();
        static int D10()
        {
            int n = _roll.Next(1, 11);
            return n;
        }
        static int D8()
        {
            int n = _roll.Next(1, 9);
            return n;
        }
        static int D6()
        {
            int n = _roll.Next(1, 7);
            return n;
        }
        static int D4()
        {
            int n = _roll.Next(1, 5);
            return n;
        }
        static int D3()
        {
            int n = _roll.Next(1, 4);
            return n;
        }
        static int D2()
        {
            int n = _roll.Next(1, 3);
            return n;
        }
    }
}
