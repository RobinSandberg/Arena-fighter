using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace arena_fighter_3.cs
{
    class Battle
    {
        public Battle()
        {
            List<string> rounds = new List<string>();  // List keeping track of every round and opponent you fight.

            Characters character = new Characters();  // Make your character here calling the character class.

            Console.WriteLine($"\nChampion : {character.Player}\nStats = Health: {character.PHealth} Damage: {character.PDamage} Strenght: {character.PStrenght}");
            Console.WriteLine("\nPick  your weapon.\n1. Sword and shield: Title Defender.\nStats - Health: + D2 Damage: + D2  Strengt: + D6.\n2. Double mace: Title Gladiator.\nStats - Damage: + D6  Strengt: + D4.\n3. Great axe: Title Warrior.\nStats - Damage: + D8  Strengt: + D2.");
            //Character stats printed out. Then ask you to pick weapon.

            WeaponSelection(character); // Calls the method for wepaon selection from below.

            Console.ReadKey(true);
            Console.Clear();

            Console.WriteLine($"\nChampion : {character.Player}\nStats = Health: {character.PHealth} Damage: {character.PDamage} Strenght: {character.PStrenght}");
            Console.WriteLine("\nPick  your armor.\n1. Heavy armor: Title Heavy.\nStats - Health: + D8 Strengt: + D2.\n2. Medium armor: Title Medium.\nStats - Health: +D6  Strengt: +D4.\n3. Light armor: Title Light.\nStats - Health: +D2  Strengt: +D8.");
            ArmorSelection(character);

            Console.ReadKey(true);
            Console.Clear();

            while (character.PHealth > 0)  // A loop for the battle that will keep going until your character hit 0 health.
            {
                Console.WriteLine($"\nChampion : {character.Player}\nStats = Health: {character.PHealth} Damage: {character.PDamage} Strenght: {character.PStrenght}");
                //Display your new character stats after picking a weapon.
                Console.WriteLine($"\nYou have {character.Gold} Gold.");
                FightSelection(character, rounds); //Menu if you wanna fight or retire your character.
   
            }
            Console.WriteLine("Final statistic about your champion.\n");
            Console.WriteLine($"\nChampion : {character.Player}\nStats = Health: {character.PHealth} Damage: {character.PDamage} Strenght: {character.PStrenght}");
            // The list printed to show your fights and Gold.
            foreach (var round in rounds)
            { 
                Console.WriteLine(round);     
            }
            
            Console.WriteLine($"\nTotal Gold: {character.Gold}");
            Console.WriteLine($"\nTotal Score: {character.score}");
            //Add each player name and the amount of gold onto the text file for saving.
            List<string> highscore = System.IO.File.ReadAllLines(@"C:\Arena fighter\highscore.txt").ToList();
            highscore.Add($"{character.Player} reached total score of: {character.score}");
            System.IO.File.WriteAllLines(@"C:\Arena fighter\highscore.txt", highscore);
            
            Console.WriteLine("\nGame Over!\nPress any key to return to menu");
            Console.ReadKey();
            Console.Clear();
        }

        public void WeaponSelection(Characters character)// Method for picking a weapon for character.
        {
            bool weapon = true; //A bool to keep the loop going until they make a proper decission.
            while (weapon)
            {
                int input = GetInput(); //Call method for user input from below to help select a weapon.

                switch (input)
                {//Roll the extra stats of the weapon you select and give you a title based on it after your name.
                    case '1':
                        Console.WriteLine("\nYou decided to use a sword and shield. Push any key to continue.");
                        character.PHealth += D2();
                        character.PDamage += D2();
                        character.PStrenght += D6();
                        character.Player += " Defender";
                        weapon = false;
                        break;
                    case '2':
                        Console.WriteLine("\nYou decided to use a double mace. Push any key to continue.");
                        character.PDamage += D6();
                        character.PStrenght += D4();
                        character.Player += " Gladiator";
                        weapon = false;
                        break;
                    case '3':
                        Console.WriteLine("\nYou decided to use a great axe. Push any key to continue.");
                        character.PDamage += D8();
                        character.PStrenght += D2();
                        character.Player += " Warrior";
                        weapon = false;
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
            }
        }
        public void ArmorSelection(Characters character)// Method for picking a armor for character.
        {
            bool armor = true; //A bool to keep the loop going until they make a proper decission.
            while (armor)
            {
                int input = GetInput(); //Call method for user input from below to help select a armor.

                switch (input)
                {//Roll the extra stats of the armor you select and give you a title based on it after your name.
                    case '1':
                        Console.WriteLine("\nYou decided to use a Heavy armor. Push any key to continue.");
                        character.PHealth += D8();
                        character.PStrenght += D2();
                        character.Player += " Heavy";
                        armor = false;
                        break;
                    case '2':
                        Console.WriteLine("\nYou decided to use a Medium armor. Push any key to continue.");
                        character.PHealth += D6();
                        character.PStrenght += D4();
                        character.Player += " Medium";
                        armor = false;
                        break;
                    case '3':
                        Console.WriteLine("\nYou decided to use a Light armor. Push any key to continue.");
                        character.PHealth += D2();
                        character.PStrenght += D8();
                        character.Player += " Light";
                        armor = false;
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }
            }
        }
            //The method for the menu for picking Opponent or retire.
            public void FightSelection(Characters character , List<string> rounds)
        {
            InfoGenerator names = new InfoGenerator(DateTime.Now.Millisecond);
            Gender gender = Gender.Any;
            bool fight = true;
            Console.WriteLine("\nTime to Decide if you wanna bring your Champion into battle. \n1. Find opponent.\n2. Shop \n3. Retire.");

            while (fight)
            {
                int input = GetInput();

                switch (input)
                {
                    case '1':
                        Console.WriteLine("\nFinding opponent get ready for battle.\n");
                        character.Opponent = names.NextFirstName(gender);
                        character.EHealth = D8() +20;
                        character.EDamage = D8() + 2;
                        character.EStrenght = D4() + 3;
                        fight = false;
                        Rounds start = new Rounds(character, rounds);
                        
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Store hold following items.\n1. Health potion: +30 health for 2 gold.\n2. Sharpening stone: +3 damage for 5 gold.\n3. Sparring session: +3 strenght for 10 gold\n4. Knight status: + 30 Health, +3 Damage, + 3 Strenght for 30 gold");
                        
                        input = GetInput();
                        if (input == '1' && character.Gold >= 2) 
                        {
                            Console.WriteLine("You bought a health potion.");
                            character.PHealth += 30;
                            character.Gold -= 2;
                        }
                        else if (input == '2' && character.Gold >= 5)
                        {
                            Console.WriteLine("You bought a sharpening stone.");
                            character.PDamage += 3;
                            character.Gold -= 5;
                        }
                        else if (input == '3' && character.Gold >= 10)
                        {
                            Console.WriteLine("You bought a sparring session.");
                            character.PStrenght += 3;
                            character.Gold -= 10;
                        }
                        else if (input == '4' && character.Gold >= 1)
                        {
                            if (input == '4' && !character.Player.Contains("Knight"))
                            {
                                
                                Console.WriteLine("You allrady bought Knight status.");
                            }
                            else
                            {
                                Console.WriteLine("You bought Knight status.");
                                character.Player += " Knight";
                                character.PHealth += 30;
                                character.PDamage += 3;
                                character.PStrenght += 3;
                                character.Gold -= 1;
                            }
                           
                        }
                        else
                        {
                            Console.WriteLine("Not enough gold or wrong input");
                        }
                        Console.WriteLine("\nPush any key to return to fight menu.");
                        Console.ReadKey(); 
                        Console.Clear();
                        Console.WriteLine($"\nChampion : {character.Player}\nStats = Health: {character.PHealth} Damage: {character.PDamage} Strenght: {character.PStrenght}");
                        Console.WriteLine("\nTime to Decide if you wanna bring your Champion into battle. \n1. Find opponent.\n2. Shop \n3. Retire.");
                        break;
                    case '3':
                        bool confirm = true;
                        Console.Clear();
                        while (confirm)
                        {
                            Console.WriteLine("You sure you wanna retire?\n1. Yes\n2. no");
                            input = GetInput();
                            if (input == '1')
                            {
                                Console.WriteLine("\nYou are retire your champion.\nPress any key to see your score.\n");
                                character.PHealth = 0;
                                fight = false;
                                confirm = false;
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (input == '2')
                            {
                                Console.Clear();
                                Console.WriteLine("Time to Decide if you wanna bring your Champion into battle. \n1.Find opponent.\n2.Shop \n3.Retire.");
                                confirm = false;
                                
                            }
                            else
                            {
                                Console.WriteLine("Wrong input");
                                confirm = true;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("wrong input");
                        break;
                }

            }
        }

        //The dices sizes between D4 and D 10
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
        static int D2()
        {
            int n = _roll.Next(1, 3);
            return n;
        }
        // Get the input and hides it on console while readkey is true.
        static char GetInput()
        {
            ConsoleKeyInfo userIn = Console.ReadKey(true);
            return userIn.KeyChar;
        }

    }

}
