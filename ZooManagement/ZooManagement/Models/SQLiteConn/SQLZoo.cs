using System.Data;
using System.Data.SQLite;

namespace ZooManagement.Models.SQLiteConn;

public partial class SQLiteConn
{
    public static Zoo ReadZoo(int id)
    {
        GetConnection();
        cmd = new SQLiteCommand(@"SELECT * FROM Zoo WHERE PK_ID = @zooid", connection);
        cmd.Parameters.AddWithValue("@zooid", id);
        SQLiteDataReader data = cmd.ExecuteReader();
        Zoo result = null;
        try
        {
            while (data.Read())
            {
                result = new Zoo(data.GetInt32(0),
                    data.GetString(1));
            }
        }
        finally
        {
            data.Close();
            connection.Close();
        }

        return result;
    }

    public static void ReadAllZoo()
    {
        GetConnection();
        cmd = new SQLiteCommand(@"SELECT * FROM Zoo", connection);
        SQLiteDataReader data = cmd.ExecuteReader();
        Zoo result = null;
        try
        {
            while (data.Read())
            {
                ZooData.Zoos.Add(new Zoo(data.GetInt32(0),
                    data.GetString(1)));
            }
        }
        finally
        {
            data.Close();
            connection.Close();
        }
    }

    public static void ReadAllData()
    {
        GetConnection();
        cmd = new SQLiteCommand(@"SELECT Count(*) FROM Zoo", connection);
        SQLiteDataReader data = cmd.ExecuteReader();
        int countZoo = 0;
        try
        {
            while (data.Read())
            {
                countZoo = data.GetInt32(0);
                Console.WriteLine(countZoo);
            }
        }
        finally
        {
            data.Close();
            connection.Close();
        }
    }

}