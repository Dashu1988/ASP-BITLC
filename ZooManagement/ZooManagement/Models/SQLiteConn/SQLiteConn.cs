using System.Data;
using System.Data.SQLite;

namespace ZooManagement.Models.SQLiteConn;

public partial class SQLiteConn
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
}