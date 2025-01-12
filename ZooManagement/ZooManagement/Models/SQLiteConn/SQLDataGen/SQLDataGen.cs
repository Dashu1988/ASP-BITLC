using System.Data;
using System.Data.SQLite;

namespace ZooManagement.Models;

public partial class SQLDataGen
{
    private static SQLiteCommand cmd;
    public static SQLiteConnection connection;
    private static readonly string pragma = "PRAGMA foreign_keys=ON;";
    private static string connString = "Data Source=zoo.sqlite;Version=3;";

    public static SQLiteConnection GetConnection()
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

        return connection;
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

    public static void DataGenerationEncolures()
    {
        for (int j = 1; j <= 40; j++)
        {
            for (int i = 1; i <= 4; i++)
            {
                cmd = new SQLiteCommand(@"
                INSERT OR IGNORE INTO Gehege (FK_WeltID)
                VALUES(@wid)"
                    , GetConnection());
                cmd.Parameters.AddWithValue("@wid", j);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }

    public static void DataGenerationAnimals()
    {
        Random rnd = new Random();
        
        int tierpassid = 1;
        for (int i = 1; i <= 160; i++)
        {
            int randomTierArt = rnd.Next(1, 18);
           
            for (int j = 1; j <= 4; j++)
            {
                cmd = new SQLiteCommand(@"
                    INSERT OR IGNORE INTO Tierpass (Name, FK_TierartID)
                    VALUES(
                           @TPName, @TAID
                           ); 



                    Insert OR IGNORE INTO Tier(FK_GehegeID, FK_TierPassID)
                    Values(@GID, @TPID)", GetConnection());
                
                
                
                cmd.Parameters.AddWithValue("@TPName", 
                    prenames[rnd.Next(prenames.Count)] + " " + surnames[rnd.Next(surnames.Count)]);

                cmd.Parameters.AddWithValue("@TAID", randomTierArt);
                
                
                cmd.Parameters.AddWithValue("@GID", i);
                cmd.Parameters.AddWithValue("@TPID", tierpassid);

                
                cmd.ExecuteNonQuery();
                connection.Close();
                randomTierArt++;
                tierpassid++;
            }
        }
    }
}