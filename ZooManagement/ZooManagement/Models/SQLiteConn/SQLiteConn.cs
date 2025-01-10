using System.Data;
using System.Data.SQLite;

namespace Zoo.Models.SQLiteConn;

public class SQLiteConn
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

    public static void InsertWelt(int zooid, string name)
    {
        GetConnection();
        cmd = new SQLiteCommand(@"
            INSERT OR IGNORE INTO Welt (FK_ZooID, Name)
            VALUES(@zooid, @name)", connection);

        cmd.Parameters.AddWithValue("@zooid", zooid);
        cmd.Parameters.AddWithValue("@name", name);

        try
        {
            cmd.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }

    public static void ReadWelt(int zooid)
    {
        GetConnection();
        SQLiteConnection conn = new SQLiteConnection(connString);
        cmd = new SQLiteCommand(@"SELECT * FROM Welt WHERE FK_ZooID = @zooid", connection);
        cmd.Parameters.AddWithValue("@zooid", zooid);
        SQLiteDataReader data = cmd.ExecuteReader();
        try
        {
            while (data.Read())
            {
                Console.WriteLine(data.GetInt32(0).ToString() + " " +
                                  data.GetInt32(1).ToString() + " " +
                                  data.GetString(2));
            }
        }
        finally
        {
            conn.Close();
            data.Close();
        }

    }
}