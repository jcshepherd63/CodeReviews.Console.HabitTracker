using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using HabitTracker.Models;
using System.Globalization;

namespace HabitTracker
{
    internal class UserSitupCrudOperations
    {
        public static void addSitups()
        {
            string situpsDate = ValidationLogic.userDateEntry();
            int situpQuantityInt = ValidationLogic.userSitupQuantEntry();
            string query = @$"INSERT INTO situps_tracking (Date, sitUpsQuantity)
                            VALUES ('{situpsDate}', {situpQuantityInt})";
       
            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var InsertCmd = connection.CreateCommand();
                InsertCmd.CommandText = query;
                InsertCmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public static void getSitupsFromDatabase()
        {
            Console.Clear();
            List<sitUpsModel> situpsData = new();
            string query = "SELECT * FROM situps_tracking";

            using(var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var GetCmd = connection.CreateCommand();
                GetCmd.CommandText = query;

                SqliteDataReader reader = GetCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        situpsData.Add(new sitUpsModel
                        {
                            sitUpsID = reader.GetInt32(0),
                            Date = reader.GetString(1),
                            sitUpsQuantity = reader.GetInt32(2)
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No rows found in the database.");
                }
                    connection.Close();
            }
            Console.WriteLine("-------------------------Situps-------------------------");
            foreach (sitUpsModel data in situpsData)
            {
                Console.WriteLine($"\t{data.sitUpsID}\t-\t{data.Date}\t-\t{data.sitUpsQuantity}");
            }
            Console.WriteLine("---------------------------------------------------------");
        }

        public static void updateSitups()
        {
            Console.Clear();
            getSitupsFromDatabase();
            int updateSitupInt = ValidationLogic.updateExerciseID();
            string situpsDate = ValidationLogic.userDateEntry();
            int situpQuantityInt = ValidationLogic.userSitupQuantEntry();
            string query = @$"UPDATE situps_tracking
                            SET Date = '{situpsDate}',
                            sitUpsQuantity = {situpQuantityInt}
                            WHERE sitUpsID = {updateSitupInt}";

            using (var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var UpdateCmd = connection.CreateCommand();
                UpdateCmd.CommandText = query;
                UpdateCmd.ExecuteNonQuery();
                connection.Close();
            }


        }

        public static void deleteSitups()
        {
            getSitupsFromDatabase();
            Console.WriteLine();
            Console.Write("Please enter the ID of the entry you wish to delete: ");
            string? deleteSitupString = Console.ReadLine();
            int deleteSitupInt = Convert.ToInt32(deleteSitupString);

            string query = $"DELETE FROM situps_tracking WHERE situpsID = {deleteSitupInt}";

            using(var connection = new SqliteConnection(Program.connectionString))
            {
                connection.Open();
                var deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = query;
                deleteCmd.ExecuteNonQuery();
                connection.Close();
            }

            Console.WriteLine($"Entry ID {deleteSitupInt} has been deleted");
        }
 
    }
}
