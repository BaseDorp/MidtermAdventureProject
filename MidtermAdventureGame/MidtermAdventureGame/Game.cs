using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermAdventureGame
{
    class Game
    {
        // Variables to make sure you don't do the same action twice
        bool InspectBox = false;
        bool TookPotion = false;

        public Game()
        {
            MainMenu();
            Player _player = new Player();
        }

        // Main Menu screen of the game. Only called once
        void MainMenu()
        {
            Console.Title = "Adventure";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"        _________ _______           _______  _        _______          
        \__    _/(  ___  )|\     /|(  ____ )( (    /|(  ____ \|\     /|
           )  (  | (   ) || )   ( || (    )||  \  ( || (    \/( \   / )
           |  |  | |   | || |   | || (____)||   \ | || (__     \ (_) / 
           |  |  | |   | || |   | ||     __)| (\ \) ||  __)     \   /  
           |  |  | |   | || |   | || (\ (   | | \   || (         ) (   
        |\_)  )  | (___) || (___) || ) \ \__| )  \  || (____/\   | |   
        (____/   (_______)(_______)|/   \__/|/    )_)(_______/   \_/   
                                                               ");
            Console.ResetColor();
            Console.WriteLine("\n\n\t\t\t    Made by Sam Hirsch\n\n\nPress any key to start...");
            Console.ReadKey();
            Console.Clear();


            Console.WriteLine("You wake up in a bed but don't know where you are. The house your in doesn't seem familiar. The house is empty besides a box, two doors, and a banana.");

            Start();
        }

        void Start()
        {
            // First Question of the game
            string[] Choice1 = { "Check the Box", "Go through back door", "Go through front door" };
            Mecanics mecanics = new Mecanics();
            switch (Mecanics.ChooseOptions(Choice1))
            {
                case 1:
                    // Only if the box hasn't been checked will it let you get a pet.
                    if (InspectBox == true)
                    {
                        Console.WriteLine("You have already checked out the box, there would be no point in doing it again");
                        Start();
                    }
                    else
                    {
                        Console.WriteLine("On the box is a sticky note that gives details about what's inside.");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\tInside are some creatures that might be able to help you. Which one would you like?");
                        Console.ResetColor();
                        string[] Choice2 = { "A Floating Mini-Whale", "A Super Speedy Pig", "A Deer that can regrow and detach it's antlers at will" };
                        string PetType;
                        switch (Mecanics.ChooseOptions(Choice2))
                        {
                            case 1:
                                PetType = "Whale";
                                break;
                            case 2:
                                PetType = "Pig";
                                break;
                            default:
                                PetType = "Deer";
                                break;
                        }
                        Console.WriteLine("What would you like to name this it?");
                        Pet _pet = new Pet(Console.ReadLine(), PetType);
                        InspectBox = true;
                        Console.Clear();
                        Console.WriteLine("You now have a companion. Now what would you like to do?");
                        Player.ItemsFound++;
                        Start();
                    }
                    break;
                    // No matter which way you go you get a banana. Never be able to come back to Start after this point
                case 2:
                    Console.WriteLine("You exit out of the backdoor.");
                    Player.Inventory.Add("Banana");
                    Player.ItemsFound++;
                    Mountain();
                    break;
                case 3:
                    Console.WriteLine("You exit out of the frontdoor.");
                    Player.Inventory.Add("Banana");
                    Player.ItemsFound++;
                    FrozenForest();
                    break;
            }
        }

        void Mountain()
        {
            Console.WriteLine("There is a giant mountain directly in front of you. The mountain is so tall that it disappears into the clouds. There is a Gondola from the base of the mountain to the top.");
            string[] Choice1;
            if (Pet.PetType != "None")
            {
                Choice1 = new string[] { "Climb the mountain", "Get in the Gondola", "Run into a tree", "Try to go back inside", "Check Inventory", "Check on Pet" };
            }
            else
            {
                Choice1 = new string[] { "Climb the mountain", "Get in the Gondola", "Run into a tree", "Try to go back inside", "Check Inventory", "Not Available" };
            }
            switch (Mecanics.ChooseOptions(Choice1))
            {
                case 1:
                    if (Pet.PetType == "Deer")
                    {
                        Console.WriteLine("You looked at {0} and then up at the top of the mountain. Soon {0}'s antlers started growing underneath you, lifting you up the mountain.");
                        TopMountain();
                    }
                    else if (Player.Inventory.Contains("Pickaxe"))
                    {
                        Console.WriteLine("You take the Pickaxe out and dig it into the side of the mountain. You start climbing to the top of the mountain.");
                        TopMountain();
                    }
                    else
                    {
                        Console.WriteLine("You make it about a foot up the mountain before sliding back down. It's no use trying without help.");
                        Mountain();
                    }
                    break;
                case 2:
                    Console.WriteLine("You wait for the next cart to come down to pick you up. When you you open the door the entire doorway is white.");
                    string[] Choice3 = { "Walk through", "Shut the door and back away" };
                    switch(Mecanics.ChooseOptions(Choice3))
                    {
                        case 1:
                            Console.WriteLine("You slowly slip in to the endless white doorway.");
                            Shop();
                            break;
                        case 2:
                            Console.WriteLine("You shut the door way and back up from it. You wonder if there is something on the other side.");
                            Mountain();
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("You run headfirst into a tree causing you to blank or for a moment");
                    Player.RemoveLife();
                    Console.WriteLine("You almost forgot that you aren't invincible");
                    Mountain();
                    break;
                case 4:
                    Console.WriteLine("You turn around to the house behind you and try to open the door. But it doesn't budge. Looks like theirs no turning back. Not like their was anything in there anyways.");
                    Mountain();
                    break;
                case 5:
                    Player.CheckInventory();
                    Mountain();
                    break;
                case 6:
                    Pet.DoSomething();
                    Mountain();
                    break;
            }
        }

        void TopMountain()
        {
            Console.WriteLine("You get off at the top of the mountain. The mountain comes to a point at the top and at the point is a single chair. Looking around the mountain, everything is covered by clouds expect for the direction that the chair is facing. In the distance their is a castle.");
            string[] Choice1 = { "Go to the Castle", "Look around", "Get in Gondola", "Check Inventory" };
            switch (Mecanics.ChooseOptions(Choice1))
            {
                // If the player has already been here they can't get the globe again
                case 1:
                    if (Player.Inventory.Contains("Magic Globe"))
                    {
                        Console.WriteLine("Luckily this side of the mountain isn't as steep. You slide down the mountain and head towards the castle.");
                    }
                    else
                    {
                        Console.WriteLine("Luckily this side of the mountain isn't as steep. You slide down the mountain and head towards the castle. On your way down you find a snow globe. Weird that this would be here. But it might have it's use later on.");
                    }
                    Castle();
                    break;
                case 2:
                    // Lets the player explor the top of mountain. They get the item to cross the lava here
                    Console.WriteLine("You look around the mountain. You think it does seem odd for just a chair to be up here. You notice under neath the chair that there is a door and a drink.");
                    if (Player.Inventory.Contains("Teleport Gun"))
                    {
                        // If player already has the teleportation then they can't get it again here
                    }
                    else
                    {
                        Console.WriteLine("You also find this something that says 'Teleportation Gun'. It reeks of potatoes but it might come in handy");
                    }
                    // Cant repeat on potions
                    if (TookPotion)
                    {
                        Console.WriteLine("You already took a potion.");
                    }
                    else
                    {
                        Console.WriteLine("You take one of the drinks. You notice it is a health potion and add it to your thing");
                        Player.Inventory.Add("Potion");
                        Player.ItemsFound++;
                        TookPotion = true;
                    }
                    Console.WriteLine("Do you want to go through the door?");
                    // Easier way for the king to get to the top of the mountain
                    string[] Choice2 = { "Yes", "No" };
                    switch (Mecanics.ChooseOptions(Choice2))
                    {
                        case 1:
                            Console.WriteLine("You push the chair out of the way and go through. You walk out in front of a castle. It seems you came through the mailbox. You have no idea how that's possible but you decide to let it go");
                            Castle();
                            break;
                        case 2:
                            Console.WriteLine("You decide to leave it alone.");
                            TopMountain();
                            break;
                    }
                    break;
                case 3:
                    Console.WriteLine("You go back to the Gondola and the door is white. You think to yourself if you want to go through.");
                    string[] Choice3 = { "Go through", "Don't go through" };
                    switch (Mecanics.ChooseOptions(Choice3))
                    {
                        case 1:
                            Console.WriteLine("You walk through the door.");
                            FrozenForest();
                            break;
                        case 2:
                            Console.WriteLine("You decide not to go through it and close the door behind you.");
                            TopMountain();
                            break;
                    }
                    break;
                case 4:
                    Player.CheckInventory();
                    TopMountain();
                    break;
            }
        }

        void FrozenForest()
        {
            Console.WriteLine("You are surrounded by a dark and green Forest. But everything is frozen over, including the green leaves. It isn't cold at all so you wonder why it would all be frozen. You walk out a little bit further trying not to slip and you notice a ice skating store. How weird that there is one in the middle of a forest but the more you think about it, the more it makes sense why an ice skating shop here.");
            string[] Choice1 = { "Keep walking into the forest", "Check out the store", "Check Inventory" };
            switch (Mecanics.ChooseOptions(Choice1))
            {
                case 1:
                    if (Player.Inventory.Contains("Ice Skates"))
                    {
                        Console.WriteLine("With your ice skates are you able to move through the forest easily. You keep wondering to the forest until you find an end. The forest starts to disappear and so does the ice. What remains is a dirt road to a castle. You take off the ice skates and head towards the castle.");
                        if (Player.Inventory.Contains("Magic Globe"))
                        {
                            Console.WriteLine("At the end of the forest, there is a globe on the ground. You wonder why this is here of all places. It could get smashed. But you take it anyways.");
                            Player.Inventory.Add("Magic Globe");
                            Player.ItemsFound++;
                        }
                        Castle();
                    }
                    else
                    {
                        Console.WriteLine("You walk a little bit further but you slip and fall. Looks like it hurt. You are able to get up and keep going throught the slippery forest.");
                        Player.RemoveLife();
                        FrozenForest();
                    }
                    break;
                case 2:
                    if (Player.Inventory.Contains("Ice Skates"))
                    {
                        Console.WriteLine("You go up to the shop and no one is there. You walk around to the side of the shop and open the door. A bright white emits from the doorframe.");
                    }
                    else
                    {
                        Console.WriteLine("You walk up to the ice skating store but no one is there. You check both ways to make sure no one is looking and then take a pair of ice skates. You relize how silly you would look stealing ice skates even if anyone was there to catch you. You also take this red drink that someone left behind. It read 'POTION' in big letters. You walk around to the door, there might me something useful inside as well. You go to open the door and the doorframe is pure white.");
                        Player.Inventory.Add("Ice Skates");
                        Player.ItemsFound++;
                        Player.Inventory.Add("Potion");
                        Player.ItemsFound++;
                    }
                    string[] Choice2 = { "Go through the door", "Close the door" };
                    switch (Mecanics.ChooseOptions(Choice2))
                    {
                        case 1:
                            Console.WriteLine("You go through the door and when you walk out you are no where near the forest. It seems you are the top of a mountain. You look at the door you just came out of and it was a gondola. The gondola you came out of is already heading down towards the base of the mountain.");
                            TopMountain();
                            break;
                        case 2:
                            Console.WriteLine("You don't want to take the chance and just slam the door and back away.");
                            FrozenForest();
                            break;
                    }
                    break;
                case 3:
                    Player.CheckInventory();
                    FrozenForest();
                    break;
            }
        }

        void Shop()
        {
            if (Player.Inventory.Contains("Pickaxe"))
            {
                Console.WriteLine("There doesn't seem to be anything here that's useful. You go back through the door.");
            }
            else
            {
                Console.WriteLine("As you walk through the door you notice you are inside. You look out the window and see a forest that has completely been frozen over. But still alive and well. You start rummeging through the stuff inside and find a pickaxe. It looks like the type you would use for hiking. You also find this something that says 'Teleportation Gun'. It reeks of potatoes but it might come in handy so you take that too. After checking everything you go back through the door.");
                Player.Inventory.Add("Pickaxe");
                Player.ItemsFound++;
                Player.Inventory.Add("Teleport Gun");
                Player.ItemsFound++;
            }
            Mountain();
        }

        void Castle()
        {
            
            Console.WriteLine("You are back at the castle.");
            string[] Choice1 = new string[] { "Try to jump across", "Look for something to use", "Use Magic Globe", "Check Inventory" };
            
            switch (Mecanics.ChooseOptions(Choice1))
            {
                case 1:
                    Console.WriteLine("You take a couple steps back to start running as fast as you can. You then jump across, only to make it halfway and fall into the lava. It's must be pretty hot in there.");
                    Player.RemoveLife();
                    Castle();
                    break;
                case 2:
                    // Executes this as long as the player has a pet
                    if (Pet.PetType != "None")
                    {
                        switch (Pet.PetType)
                        {
                            case "Whale":
                                Console.WriteLine("Your friend {0} nudges you to get on it's back. You proceed to do so and then both of you fly across the lava.", Pet.PetName);
                                InsideCastle();
                                break;
                            case "Pig":
                                Console.WriteLine("Your friend {0} nudges you to get on it's back. You proceed to do so. {0} gets into a running position and then zooms across the lava.", Pet.PetName);
                                InsideCastle();
                                break;
                            case "Deer":
                                Console.WriteLine("Your friend {0} nudges you. {0} then proceeds to man a bridge using it's antlers.", Pet.PetName);
                                InsideCastle();
                                break;
                        }
                    }
                    // Only checks if they ahve the teleport gun if they dont ahve a pet
                    else if (Pet.PetType == "None")
                    {
                        if (Player.Inventory.Contains("Teleport Gun"))
                        {
                            Console.WriteLine("You take out the Portal Gun and point it at the castle wall across the river. You shoot another on underneath you. You heart jumps when you start falling. But you end up face first on the other side by the castle.");
                            InsideCastle();
                        }
                        Console.WriteLine("You check everything on you but it doesn't seem to be anything that will help you get across. Maybe going back you might find something to get across.");
                        Castle();
                    }
                    break;
                case 3:
                    MagicGlobe();
                    break;
                case 4:
                    Player.CheckInventory();
                    Castle();
                    break;
            }
        }

        void InsideCastle()
        {
            Console.WriteLine("You make it to the castle doors. You go to open them and sigh in relief when the doorframe isn't glowing white. You look inside and it is a long red carpet leading up to this huge chair. The chair is very well polished but nothing else inside if taken care of. Sitting in the chair is a monkey. You proceed to keep walking in and the monkey notices you and stop chewing on the staff it has. It bares it's teeth at you and starts running towards you. You take off your bag and throw it. It misses completely but the monkey turns around and keep going through your bag. It finds the banana in your bag and starts eating it.");
            string[] Choice1 = { "Take the staff", "Try and take the banana from the monkey. He's stealing!" };
            switch (Mecanics.ChooseOptions(Choice1))
            {
                case 1:
                    Console.WriteLine("While the monkey isn't paying attention you run and grab the staff. You look at the staff in your hands and it glows. You hear yelling from the back asking for help. You run to go help him. Once the monkey notices you, he finishes the banana and start running after you. You realize he's going to catch up to you and you swing the staff at him. Something sparks in the staff and the monkey freezes in place. You run towards the voice and it's an old man behind some bars.");
                    break;
                case 2:
                    Console.WriteLine("You race at the monkey and start fighting it for the banana. Then you hear a voice from the back of the castle. 'Just let him have the banana and come help me!' You let him have the banana, grab the staff, and run towards the voice. At the back of teh castle is an old man behind bars");
                    break;
            }
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Old Man: Hand me the staff!");
            Console.ResetColor();
            Console.WriteLine("You hand him the staff and he raises it up in the air. Doing so makes all the bars disappear. He walks out and heads towards the monkey. The monkey just finished it's banana and looks at the old man wide eyed. The staf brings the monkey to the old man and onto his shoulder");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("King: Sorry about that. He tends to get a little carried away sometimes. I am the king of the land. Usually it is a lot nicer than what it is now. Considering my little friend here froze over the forest a long time ago. He also messed up all the doors. I guess he doesn't know how doors work. I tried to wake you up sooner to help me but it took a long time for you to wake up. It seems you found my snow globe. Don't worry about returning it. I hope you can find more use to it than me. Now that I am back here everything is well again. You can continue your journey elsewhere. Thanks again.");
            Console.ResetColor();
            Console.WriteLine("\n\n\nPress any key to continue...");
            End();
        }

        void End()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"_________          _______    _______  _        ______  
\__   __/|\     /|(  ____ \  (  ____ \( (    /|(  __  \ 
   ) (   | )   ( || (    \/  | (    \/|  \  ( || (  \  )
   | |   | (___) || (__      | (__    |   \ | || |   ) |
   | |   |  ___  ||  __)     |  __)   | (\ \) || |   | |
   | |   | (   ) || (        | (      | | \   || |   ) |
   | |   | )   ( || (____/\  | (____/\| )  \  || (__/  )
   )_(   |/     \|(_______/  (_______/|/    )_)(______/ 
                                                        ");

            if (Pet.PetType != "None")
            {
                Console.WriteLine("\n\n\nYou and your companion {0} completed the Journey", Pet.PetName);
            }
            else
            {
                Console.WriteLine("\n\n\nYou managed to make it through the game without the need of a companion");
            }
            Console.WriteLine("You made it with {0} out of 3 Lives", Player.Lifes);
            if (Player.UsedPotion == false)
            {
                Console.WriteLine("You made it all the way through without using a potion");
            }
            else
            {
                Console.WriteLine("You used a Potion during you play through. Next time try to make it through without using a potion");
            }
            Console.WriteLine("You found {0} out of the 8 total items that can be found. Play again and explore everything if you want to.", Player.ItemsFound);

            Console.WriteLine("\n\n\nPress any key to Quit");
            Console.ReadKey();
            Environment.Exit(0);
        }

        void MagicGlobe()
        {
            // Was the kings but he lost it so this allows the player to back track and find items
            Console.WriteLine("You pull out the magic globe and look into it. You see a bunch of places that you've been before.");
            string[] Places = { "Mountains", "Frozen Forest", "Castle" };
            switch (Mecanics.ChooseOptions(Places))
            {
                case 1:
                    Console.WriteLine("You shake the globe and it shines brightly. You close your eyes, shielding them from the light. When you open them back up your at the base of the mountain.");
                    Mountain();
                    break;
                case 2:
                    Console.WriteLine("You shake the magic globe and you see inside it starts to snow. Next thing you know your being washed away. When you open your eyes again you notice that the place looks familiar.");
                    FrozenForest();
                    break;
                case 3:
                    Console.WriteLine("You shake the magic globe. You start to feel light headed. Next time you open your eyes, you back at the castle.");
                    Castle();
                    break;
            }
        }
    }
}
