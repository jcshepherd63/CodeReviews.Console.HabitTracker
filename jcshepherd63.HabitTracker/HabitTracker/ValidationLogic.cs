using System;
using System.Collections.Generic;
using System.Text;

namespace HabitTracker
{
    public class ValidationLogic
    {
        public static string userDateEntry()
        {
            Console.Clear();
            Console.WriteLine("Please enter the date of the exercise you are adding (mm-dd-yyyy) : ");
            string? Date = Console.ReadLine();
            while(Date == null || Date == "")
            {
                Console.WriteLine("That is not a valid date entry. Please try again.");
                Console.WriteLine("Please enter the date of the exercise you are adding (mm-dd-yyyy) : ");
                Date = Console.ReadLine();
            }
            return Date;
        }

        public static int userPushupQuantEntry()
        {
            Console.WriteLine("Please enter the quantity of pushup : ");
            string? pushupQuantity = Console.ReadLine();
            int pushupQuantityInt;
            bool success = int.TryParse(pushupQuantity, out pushupQuantityInt);
            if (success)
            {
                return pushupQuantityInt;
            }
            else
            {
                Console.WriteLine("That was not a valid number entry. Please try again.");
                return userPushupQuantEntry();
            }

            return pushupQuantityInt;

        }

        public static int userSitupQuantEntry()
        {
            Console.WriteLine("Please enter the quantity of situps : ");
            string? situpQuantity = Console.ReadLine();
            int situpQuantityInt;
            bool success = int.TryParse(situpQuantity, out situpQuantityInt);
            if (success)
            {
                return situpQuantityInt;
            }
            else
            {
                Console.WriteLine("That is not a valid number entry. Please try again.");
                return userSitupQuantEntry();
            }

        }

        public static int updateExerciseID()
        {
            Console.WriteLine("Enter the ID of the record you wish to update. : ");
            string? updateIDString = Console.ReadLine();
            int updateExerciseInt;
            bool success = int.TryParse(updateIDString, out updateExerciseInt);
            if (success)
            {
                return updateExerciseInt;
            }
            else
            {
                Console.WriteLine("That is not a valid number entry. Please try again.");
                return updateExerciseID();
            }
        }
    }
}
