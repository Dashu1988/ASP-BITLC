using System.Data.SQLite;

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
      
      static public void InsertData(SQLiteConnection conn)
      {
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "INSERT INTO Einkaufsliste VALUES ('Bier', 666, 'Penny');";
         sqlite_cmd.ExecuteNonQuery();
         

      }

      static public void ReadData(SQLiteConnection conn)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "SELECT * FROM Einkaufsliste";

         sqlite_datareader = sqlite_cmd.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            string myreader = sqlite_datareader.GetString(0) +" "+ 
                              sqlite_datareader.GetInt32(1).ToString() +" "+
                              sqlite_datareader.GetString(2);
            Console.WriteLine(myreader);
         }
         conn.Close();
      }
   }
}