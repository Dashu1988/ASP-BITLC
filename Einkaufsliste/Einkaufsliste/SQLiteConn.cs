using System.Data.SQLite;
using System.Security.Cryptography;
using Einkaufsliste.Models;

namespace Einkaufsliste
{
    class SQLiteConn
    {
        static public SQLiteConnection sqlite_conn;

        static public SQLiteConnection CreateConnection()
        {
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=../db.sqlite;Version=3;New=False;Compress=True;");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
            }

            return sqlite_conn;
        }

        static public void InsertData(Position p)
        {
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();

            string query = @" INSERT INTO einkaufsliste (Name, Menge, Shop) 
                     VALUES (@name, @menge, @shop) 
                     ON CONFLICT (Name, Shop) 
                     DO 
                        UPDATE SET menge = einkaufsliste.Menge + @menge
                        WHERE Name = @name AND Shop = @shop";
            sqlite_cmd.CommandText = query;
            sqlite_cmd.Parameters.AddWithValue("@name", p.Name);
            sqlite_cmd.Parameters.AddWithValue("@menge", p.Menge);
            sqlite_cmd.Parameters.AddWithValue("@shop", p.Shop);
            sqlite_cmd.ExecuteNonQuery();


            conn.Close();
            ReadData();
        }

        static public void DeleteData(Position p)
        {
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            string query = @" DELETE FROM Einkaufsliste WHERE Name = @name AND Shop = @shop";
            sqlite_cmd.CommandText = query;
            sqlite_cmd.Parameters.AddWithValue("@name", p.Name);
            sqlite_cmd.Parameters.AddWithValue("@shop", p.Shop);
            sqlite_cmd.ExecuteNonQuery();
            conn.Close();
            ReadData();
        }

        static public void ReadData()
        {
            SQLiteConnection conn = CreateConnection();
            Repository.Pos.Clear();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Einkaufsliste";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Position temp = new Position();
                temp.Name = sqlite_datareader.GetString(0);
                temp.Menge = sqlite_datareader.GetInt32(1);
                temp.Shop = sqlite_datareader.GetString(2);
                Repository.Pos.Add(temp);
            }

            conn.Close();
        }
        
    }
}