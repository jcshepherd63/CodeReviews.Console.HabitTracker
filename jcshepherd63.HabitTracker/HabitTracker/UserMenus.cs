using HabitTracker;
using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTrackerMenus
{
    internal class UserMenus
    {
        public static void mainMenu()
        {
            Console.WriteLine("Welcome to the Exercise Habit Tracking App!");
            Console.WriteLine("--------------------------------------------------------\n\n");
            Console.WriteLine("Which exercise would you like to work with currently?\n");
            Console.WriteLine("1. Pushups");
            Console.WriteLine("2. Situps");
            Console.WriteLine("3. Quit App");
            Console.WriteLine("--------------------------------------------------------\n");
            mainMenuRouter();
        }
        
        public static void pushUpMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------Pushup Menu----------------------");
            Console.WriteLine("\nWhat would you like to do in the pushup menu?\n");
            Console.WriteLine("1. Add new pushups");
            Console.WriteLine("2. Update pushup entry");
            Console.WriteLine("3. Delete pushup entry");
            Console.WriteLine("4. View all pushup entries");
            Console.WriteLine("5. Go back to main menu");
            Console.WriteLine("--------------------------------------------------------\n");
            UserExerciseMenuRouters.pushUpMenuRouter();
        }

        public static void sitUpMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------Situp Menu----------------------");
            Console.WriteLine("\nWhat would you like to do in the situp menu?\n");
            Console.WriteLine("1. Add new situps");
            Console.WriteLine("2. Update situp entry");
            Console.WriteLine("3. Delete situp entry");
            Console.WriteLine("4. View all situp entries");
            Console.WriteLine("5. Go back to main menu");
            Console.WriteLine("--------------------------------------------------------\n");
            UserExerciseMenuRouters.sitUpMenuRouter();
        }

        public static void mainMenuRouter()
        {
            string? userMainMenuSelection = Console.ReadLine();
            int userSelectionNumber;
            bool success = int.TryParse(userMainMenuSelection, out userSelectionNumber);
            if (!success)
            {
                Console.WriteLine("That was not a valid number entry. Please try again.");
                mainMenuRouter();
            }

                switch (userSelectionNumber)
                {
                    case 1:
                        pushUpMenu();
                        break;
                    case 2:
                        sitUpMenu();
                        break;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("That was an invalid option.");
                        Console.WriteLine("Please enter any key to return to the main menu and start over.");
                        Console.ReadLine();
                        Console.Clear();
                        mainMenu();
                        break;
                }
        }

    }
}
