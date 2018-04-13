using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace arena_fighter_3.cs
{
    class Characters
    {
        public string Player;
        public string Opponent;
        public int Gold = 0;// Starting number for the gold.
        public int score = 0;
        // Random and set numbers added to your stats and the Opponents stats.
        public int PHealth = D10() + 40;
        public int EHealth = D8() + 20;
        public int PDamage = D10() + 5;
        public int EDamage = D8() + 2;
        public int PStrenght = D4() + 6;
        public int EStrenght = D4() + 3;

        public Characters() // Naming your character here.
        {
            bool naming = true;
            Player = Console.ReadLine();
            while (naming)
            {
                if (Player == "")//If no name added to string
                { 
                    Console.Write("\nEnter a name: ");
                    Player = Console.ReadLine();
                    naming = true;
                }
                else
                {
                    naming = false;
                }
                
            }
 
        }
       
        static Random _roll = new Random(); // Random rolled dice from 1 to 10.
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
        
    }
}
