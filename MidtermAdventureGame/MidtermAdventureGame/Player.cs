using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MidtermAdventureGame
{
    class Player
    {
        public static List<string> Inventory = new List<string>();
        public static int Lifes = 3;
        static bool AllLifes = false;
        static public int ItemsFound;
        static public bool UsedPotion = false;

        

        static public void CheckInventory()
        {
            Console.WriteLine("You check for everything on you and this is all that you find.");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < Inventory.Count; i++)
            {
                Console.WriteLine(Inventory[i]);
            }
            Console.ResetColor();
            if (Player.Inventory.Contains("Potion") && Lifes < 3)
            {
                Console.WriteLine("You would like to use this potion? It will refil 1 Life Point. You currently have {0} out of 3", Lifes);
                string[] Choose = { "Yes", "No" };
               switch (Mecanics.ChooseOptions(Choose))
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You went from {0} life to {1} life.", Lifes, Lifes + 1);
                        Console.ResetColor();
                        Lifes++;
                        UsedPotion = true;
                        break;
                    case 2:
                        break;
                }
                    
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        static public void RemoveLife()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("You went from {0} life to {1} life.", Lifes, Lifes-1);
            Console.ResetColor();
            Lifes--;
            if (AllLifes == false)
            {
                Console.WriteLine("You notice this is your first time doing something not smart. Doing not smart things makes you lose a life. If you lose all three, not good things happen, so try not to.");
            }
            AllLifes = true;
            if (Lifes == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(@"         _______  _______  _______  _______    _______           _______  _______ 
        (  ____ \(  ___  )(       )(  ____ \  (  ___  )|\     /|(  ____ \(  ____ )
        | (    \/| (   ) || () () || (    \/  | (   ) || )   ( || (    \/| (    )|
        | |      | (___) || || || || (__      | |   | || |   | || (__    | (____)|
        | | ____ |  ___  || |(_)| ||  __)     | |   | |( (   ) )|  __)   |     __)
        | | \_  )| (   ) || |   | || (        | |   | | \ \_/ / | (      | (\ (   
        | (___) || )   ( || )   ( || (____/\  | (___) |  \   /  | (____/\| ) \ \__
        (_______)|/     \||/     \|(_______/  (_______)   \_/   (_______/|/   \__/");
                Console.ResetColor();
                Console.WriteLine("This is the end of the Adventure. You have run out of lives. Press any button to retry your Adventure...");

                Console.ReadKey();
                Environment.Exit(0);
                // Closes the program after player hits 0 lives
                // Environment.Exit(0) is from Danny Beckett at https://stackoverflow.com/questions/5682408/command-to-close-an-application-of-console
            }
        }
    }
}
