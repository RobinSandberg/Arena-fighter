using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace arena_fighter_3.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true) //Keeping the game alive until the player wanna exit.
            {
                Menu menu = new Menu(); //Call up and starts the game menu.
                menu.GameMenu();

                Console.Write("Get started with your Arena fighter.\nName your champion: ");

                Battle game = new Battle(); // Starts the game itself.
                
            }

        }
        
    }
}
