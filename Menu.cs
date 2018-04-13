using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arena_fighter_3.cs
{
    class Menu
    {
        public void GameMenu()
        {
            bool start = true;
            //Console.WriteLine("Welcome To Arena fighter.\n1. Play Game\n2. Game infomation\n3. Exit Game");

            while (start)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nIMPORTANT! Make sure you got the Arena fighter folder in C: like this C:Arena fighter.\nThis is where the highscore list will be saved without folder game crash.\nAfter you have the folder activate the list with the make new highscore list command.\nThis will allso reset the list if you wanna start a new.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\nWelcome To Arena fighter.\n1. Play Game\n2. Game Infomation\n3. View Highscore\n\n4. Make New Highscore List\n5. Exit Game");
                int input = GetInput();
                // Try to fix the repeat of menu text when wrong input if 2 can jump back toward the start of the menu.
                switch (input)
                {
                    case '1':
                        start = false;
                        Console.Clear();
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("\nStat info:\nHealth: Is how much damage you can take before losing.\nDamage: Is how much health you remove from your opponent.\nStrenght: Added to your dice roll for attacks highest roll strikes.");
                        Console.WriteLine("\nDice info:\nThe fight is rolled with a D6 + your strenght.\nD4 is 1-4 , D6 is 1-6 , D8 is 1-8 and D10 is 1-10.");
                        Console.WriteLine("\nWeapon info:\nDefender: Is a sword and shield user.\nGladiator: Is a double mace use.\nWarrior: Is a great axe user.\nBoss: Is a slightly strong opponent.");
                        Console.WriteLine("\nArmor info: You got 3 types of armor heavy , medium and light.\nThey will be added to your name after your weapon title.");
                        Console.WriteLine("\nReward info:\nAfter each round the player will pull randomly out of 10 rewards to be added to his stats.\nOpponent will be rewarded 5 health and +1 to all stats after each round to make them stronger over time.");
                        Console.WriteLine("\nPush any key to get back to Menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                        
                    case '3':
                        Console.Clear();// Reads the text file with the collected scores.
                        string[] highscore = System.IO.File.ReadAllLines(@"C:\Arena fighter\highscore.txt");
                        foreach (var line in highscore)
                        {
                            Console.WriteLine(line + "\n");
                        }
                        Console.ReadKey();
                        Console.Clear();          
                        break;

                    case '4':
                        //Make a list ontop of starting the game if there is non in C:Arena fighter folder.
                        string score = "Highscore List;\nPress any key to return to Menu.";
                        System.IO.File.WriteAllText(@"C:\Arena fighter\highscore.txt", score);
                        break;

                    case '5':
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nwrong input\n");
                        break;
                        
                }
                

            }
        }
        static char GetInput()
        {
            ConsoleKeyInfo userIn = Console.ReadKey(true);
            return userIn.KeyChar;
        }
    }
}
