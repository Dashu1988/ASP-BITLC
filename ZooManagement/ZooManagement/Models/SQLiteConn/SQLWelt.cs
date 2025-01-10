using System.Data;
using System.Data.SQLite;
namespace ZooManagement.Models.SQLiteConn;

public partial class SQLiteConn
{
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

    
    public static void ReadWelt(Zoo z)
    {
        GetConnection();
        cmd = new SQLiteCommand(@"SELECT * FROM Welt WHERE FK_ZooID = @zooid", connection);
        cmd.Parameters.AddWithValue("@zooid", z.ID);
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
            data.Close();
            connection.Close();
        }
    }
}