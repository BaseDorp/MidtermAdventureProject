using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermAdventureGame
{
    class Pet
    {
        public static string PetName;
        public static string PetType = "None";

        public Pet(string _name, string _type)
        {
            PetName = _name;
            PetType = _type;
        }

        static public void DoSomething()
        {
            if (PetType == "None")
            {
                Console.WriteLine("You look to your side but their's nothing there. Maybe you missed something at the beggining.");
            }
            else if (PetType == "Whale")
            {
                Console.WriteLine("You look at your pet whale while it's floating next to you. It looks back at you, squirts water into your face, and then looks back forward like nothing happened.");
            }
            else if (PetType == "Pig")
            {
                Console.WriteLine("{0} is not paying attention. {0} is looking for something to eat.", PetName);
            }
            else if (PetType == "Deer")
            {
                Console.WriteLine("{0} is standing there like a deer in headlights.", PetName);
            }
        }
    }
}
