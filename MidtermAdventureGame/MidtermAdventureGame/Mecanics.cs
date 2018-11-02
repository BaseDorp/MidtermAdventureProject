using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Jethro helped me on debugging this part of my code

namespace MidtermAdventureGame
{
    class Mecanics
    {
        // Takes in an array of options
        public static int ChooseOptions(string[] _options)
        {
            for (int i = 0; i < _options.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("{0}. {1}",i+1,_options[i]);
            }
            Console.ResetColor();
            int NumberInput = 0;
            // TryParse code from Marco at https://stackoverflow.com/questions/24443827/reading-an-integer-from-user-input
            // Takes what the user puts in and turns it to an int without breaking if the user types in a non numberical value
            Int32.TryParse(Console.ReadLine(), out NumberInput);
            Console.Clear();
            if (NumberInput > _options.Length || NumberInput <= 0)
            {
                Console.WriteLine("This isn't an option. Please try again...\n");
                // I had it as just ChooseOptions(_options) but there was a bug when returning it and Jethro helped me fix it
                NumberInput = ChooseOptions(_options);
            }
            return NumberInput;
        }
    }
}
