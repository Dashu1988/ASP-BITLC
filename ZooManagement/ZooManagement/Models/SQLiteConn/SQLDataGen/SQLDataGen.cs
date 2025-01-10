using System.Data;
using System.Data.SQLite;

namespace ZooManagement.Models;

public partial class SQLDataGen
{
    private static SQLiteCommand cmd;
    public static SQLiteConnection connection;
    private static readonly string pragma = "PRAGMA foreign_keys=ON;";
    private static string connString = "Data Source=zoo.sqlite;Version=3;";

    public static void GetConnection()
    {
        if (connection == null)
        {
            connection = new SQLiteConnection(connString);
        }

        try
        {
            connection.Open();
        }
        finally
        {
        }
    }
    public static void DataGenerationWorlds()
    {
        GetConnection();
        Random rnd = new Random();

        for (int i = 1; i <= 10; i++)
        {
            var tempWorldNames = WorldNames;
            for (int j = 1; j <= 4; j++)
            {
                cmd = new SQLiteCommand(@"
                        INSERT OR IGNORE INTO Welt (FK_ZooID, Name)
                        VALUES(@zooid, @name)"
                    , connection);

                cmd.Parameters.AddWithValue("@zooid", i);
                string world = tempWorldNames[rnd.Next(tempWorldNames.Count)];
                cmd.Parameters.AddWithValue("@name", world);
                tempWorldNames.Remove(world);
                cmd.ExecuteNonQuery();
            }
        }


        connection.Close();
    }

    public static void DataGenerationAnimals()
    {
        Random rnd = new Random();

        GetConnection();

      
        
        foreach(string s in AnimalTypes)
        {
            cmd = new SQLiteCommand(@"
                    INSERT OR IGNORE INTO Tierart (Name)
                    VALUES(
                           @name
                           )", connection);
            cmd.Parameters.AddWithValue("@name", s);
            cmd.ExecuteNonQuery();
        }
       
        connection.Close();
    }
}