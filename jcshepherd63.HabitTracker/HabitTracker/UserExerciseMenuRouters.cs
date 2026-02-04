using System;
using System.Collections.Generic;
using System.Text;
using HabitTrackerMenus;

namespace HabitTracker
{
    internal class UserExerciseMenuRouters
    {
        public static void pushUpMenuRouter()
        {
            string returntoMainMenu = "Press any key to return to the main menu.";
            string? userPUMenuSelection = Console.ReadLine();
            int userSelectionNumber = Convert.ToInt32(userPUMenuSelection);  //THIS NEEDS CHANGED TO A TRYPARSE IN CASE A USER ENTERS ANYTHING OTHER THAN A NUMBER.

            switch (userSelectionNumber)
            {
                case 1:
                    UserPushupCrudOperations.addPushups();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 2:
                    UserPushupCrudOperations.updatePushups();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 3:
                    UserPushupCrudOperations.deletePushups();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 4:
                    UserPushupCrudOperations.GetPushupsFromDatabase();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 5:
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                default:
                    Console.WriteLine("That was an invalid option.");
                    Console.WriteLine("Please enter any key to return to the pushup menu and start over.");
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.pushUpMenu();
                    break;
            }
        }

        public static void sitUpMenuRouter()
        {
            string returntoMainMenu = "Press any key to return to the main menu.";
            string? userSUMenuSelection = Console.ReadLine();
            int userSelectionNumber = Convert.ToInt32(userSUMenuSelection);  //THIS NEEDS CHANGED TO A TRYPARSE IN CASE A USER ENTERS ANYTHING OTHER THAN A NUMBER.

            switch (userSelectionNumber)
            {
                case 1:
                    UserSitupCrudOperations.addSitups();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 2:
                    UserSitupCrudOperations.updateSitups();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 3:
                    UserSitupCrudOperations.deleteSitups();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 4:
                    UserSitupCrudOperations.getSitupsFromDatabase();
                    Console.WriteLine(returntoMainMenu);
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                case 5:
                    Console.Clear();
                    UserMenus.mainMenu();
                    break;
                default:
                    Console.WriteLine("That was an invalid option.");
                    Console.WriteLine("Please enter any key to return to the situp menu and start over.");
                    Console.ReadLine();
                    Console.Clear();
                    UserMenus.sitUpMenu();
                    break;
            }
        }
    }
}
