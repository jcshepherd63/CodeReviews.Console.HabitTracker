using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using HabitTracker.Models;

namespace HabitTracker
{
    internal class UserPushupCrudOperations
    {
        public static void addPushups()
        {
            string pushupsDate = ValidationLogic.userDateEntry();
            int quantityNumber = ValidationLogic.userPushupQuantEntry();
            string query = @$"INSERT INTO pushups_tracking (Date, pushUpsQuantity)
                           VALUES ('{pushupsDate}', {quantityNumber})";

            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = query;
                insertCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void GetPushupsFromDatabase()
        {
            Console.Clear();
            List<pushUpsModel> pushupData = new();
            string query = "SELECT * FROM pushups_tracking";
            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var getCmd = connection.CreateCommand();
                getCmd.CommandText = query;

                SqliteDataReader reader = getCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        pushupData.Add(
                            new pushUpsModel
                            {
                                pushUpsID = reader.GetInt32(0),
                                Date = reader.GetString(1),
                                pushUpsQuantity = reader.GetInt32(2)
                            });
                    }

                }
                else
                {
                    Console.WriteLine("No rows found in the database.");
                }
                    connection.Close();
            }
            Console.WriteLine("-------------------------Pushups-------------------------");
            foreach (pushUpsModel data in pushupData)
            {
                Console.WriteLine($"\t{data.pushUpsID}\t-\t{data.Date}\t-\t{data.pushUpsQuantity}");
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        public static void updatePushups()
        {
            Console.Clear();
            GetPushupsFromDatabase();
            Console.WriteLine("Please enter the ID of the record you wish to update.");
            string? updatePushupIDString = Console.ReadLine();
            int updatePushupInt = ValidationLogic.updateExerciseID();
            string pushupsDate = ValidationLogic.userDateEntry();
            int pushupQuantity = ValidationLogic.userPushupQuantEntry();
            string query = @$"UPDATE pushups_tracking 
                            SET Date = '{pushupsDate}', 
                            pushUpsQuantity = {pushupQuantity}
                            WHERE pushUpsID = {updatePushupInt}";

            using(var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var UpdateCmd = connection.CreateCommand();
                UpdateCmd.CommandText = query;
                UpdateCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void deletePushups()
        {
            GetPushupsFromDatabase();
            Console.WriteLine();
            Console.Write("Please enter the ID of the record you wish to delete: ");
            string? deletePushupID = Console.ReadLine();
            int deleteIDInt = Convert.ToInt32(deletePushupID);

            string query = $@"DELETE FROM pushups_tracking WHERE pushupsID = {deleteIDInt}";

            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = query;
                deleteCmd.ExecuteNonQuery();
                connection.Close();
            }

            Console.WriteLine($"Entry ID {deleteIDInt} has been deleted.");
        }

        

    }
}
