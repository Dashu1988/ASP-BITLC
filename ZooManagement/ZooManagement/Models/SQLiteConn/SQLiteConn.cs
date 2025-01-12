using System.Data;
using System.Data.SQLite;

namespace ZooManagement.Models;

public partial class SQLiteConn
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
            return connection;
        }finally{}
       
    }

    public static List<Zoo> ReadAllZoo()
    {
        List<Zoo> zoos = new List<Zoo>();
        GetConnection();
        cmd = new SQLiteCommand(@"
            SELECT * FROM Zoo"
            , connection);
        SQLiteDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            zoos.Add(new Zoo(
                data.GetInt32(0),
                data.GetString(1)
                ));
        }
        
        data.Close();
        connection.Close();
        return zoos;
    }

    public static Zoo ReadZoo(int zid)
    {
        Zoo zoo;
        SQLiteDataReader data;
        
        
        // Read Zoo Meta Data
        cmd = new SQLiteCommand(@"
                           SELECT * FROM Zoo
                           WHERE PK_ID = @zid
            ", GetConnection());
        cmd.Parameters.AddWithValue("@zid", zid);
        data = cmd.ExecuteReader();
        data.Read();
        zoo = new Zoo(data.GetInt32(0), data.GetString(1));
        data.Close();
        connection.Close();
        // Read All Worlds
        zoo.Welten = ReadWorlds(zoo.ID);
        // Read All Enclosures
        
        // Read All Animal
        
        return zoo;
    }

    public static List<Welt> ReadWorlds(int zid)
    {
        List<Welt> worlds = new List<Welt>();
        cmd = new SQLiteCommand(@"SELECT * FROM Welt WHERE FK_ZooID = @zooid", GetConnection());
        cmd.Parameters.AddWithValue("@zooid", zid);
        SQLiteDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            worlds.Add(new Welt(data.GetInt32(0), data.GetInt32(1), data.GetString(2)));
        }
        data.Close();
        connection.Close();
        return worlds;
    }
    public static List<Gehege> ReadEnclosures(int wid)
    {
        List<Gehege> results = new List<Gehege>();
        cmd = new SQLiteCommand(@"SELECT * FROM Gehege WHERE FK_WeltID = @wid",GetConnection());
        cmd.Parameters.AddWithValue("@wid", wid);
        SQLiteDataReader data = cmd.ExecuteReader();
        while (data.Read())
        {
            results.Add(new Gehege(data.GetInt32(0), data.GetInt32(1)));
        }
        
        data.Close();
        connection.Close();

        foreach (Gehege g in results)
        {
            g.Tiere = ReadAnimals(g.ID);
        }
        return results;
    }

    public static List<Tier> ReadAnimals(int gid)
    {
        List<Tier> results = new List<Tier>();
        cmd = new SQLiteCommand(@"

            SELECT 
                Tier.PK_ID, Tier.FK_GehegeID,
                Tierpass.PK_ID, Tierpass.Name,
                Tierart.PK_ID, Tierart.Name
            FROM Tier
            JOIN Tierpass on Tier.FK_TierpassID = Tierpass.PK_ID
            JOIN Tierart ON Tierpass.FK_TierartID = Tierart.PK_ID

            WHERE FK_GehegeID = @gid
"
            
            , GetConnection());
        cmd.Parameters.AddWithValue("@gid", gid);
        SQLiteDataReader data = cmd.ExecuteReader();

        while (data.Read())
        {
            //JOIN Tier, Tierpass, Tierart 
            // Tier(int id, int gehegeid, Tierpass tierpass)
            // Tierpass(int id, string name, Tierart tierartid)
            // Tierart(int id, string name)

            results.Add(
                new Tier(data.GetInt32(0),
                    data.GetInt32(1),
                    new Tierpass(
                        data.GetInt32(2),
                        data.GetString(3),
                        new Tierart(
                            data.GetInt32(4),
                            data.GetString(5)
                        )

                    )
                )
            );
        }

        return results;
    }
    
}