using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arena_fighter_3.cs
{
    class Highscore
    {
        public void Score(Characters character)
        {
            List<string> highscores = new List<string>();
            foreach (var Player in highscores)
            {
                Console.WriteLine(Player + $"\nTotal score {character.Gold}");

            }
            
        }
        

    }
}
