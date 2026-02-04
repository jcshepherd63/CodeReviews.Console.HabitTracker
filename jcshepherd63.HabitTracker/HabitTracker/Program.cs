using Microsoft.Data.Sqlite;
using System;
using HabitTrackerMenus;


internal class Program
{
    public static readonly string connectionString = @"Data Source=habitTracker.db";
    private static void Main(string[] args)
    {
        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            var tableCmd = connection.CreateCommand();

            tableCmd.CommandText =
                                @"CREATE TABLE IF NOT EXISTS pushups_tracking (
                                pushUpsID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Date TEXT,
                                pushUpsQuantity INTEGER
                                );

                                CREATE TABLE IF NOT EXISTS situps_tracking (
                                sitUpsID INTEGER PRIMARY KEY AUTOINCREMENT,
                                Date TEXT, 
                                sitUpsQuantity INTEGER
                                );";

            tableCmd.ExecuteNonQuery();

            connection.Close();
        }

        UserMenus.mainMenu();
    }
}