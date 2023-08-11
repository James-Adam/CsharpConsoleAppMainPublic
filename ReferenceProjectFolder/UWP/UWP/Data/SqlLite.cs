using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UWP.Data
{
    //adding sqlLite to a UWP App
    public class SqlLite
    {
        //in-app crud operations
        private readonly List<string> Data = new List<string>();

        public void UseSqlLite()
        {
            using (SqlConnection sc = new SqlConnection("Filename=mydb.db"))
            {
                sc.Open();

                sc.Close();
            }
        }

        //Managing sqlLite database
        public void SetupDb()
        {
            using (SqliteConnection sc = new SqliteConnection("Filename=mydb.db"))
            {
                sc.Open();
                SqliteCommand cmd =
                    new SqliteCommand(
                        "CREATE TABLE IF NOT EXISTS DbTable (MyPK INTEGER PRIMARY KEY AUTOINCREMENT, Data NVARCHAR(2048) NULL)",
                        sc);

                _ = cmd.ExecuteNonQuery();
            }
        }

        public void InsertData()
        {
            using (SqliteConnection sc = new SqliteConnection("Filename=mydb.db"))
            {
                sc.Open();
                SqliteCommand cmd = new SqliteCommand("INSERT INTO DbTable VALUES (NULL, @Data);", sc);
                _ = cmd.Parameters.AddWithValue("@Data", "My data to be inserted into the database");

                int number = cmd.ExecuteNonQuery();

                cmd = new SqliteCommand("SELECT Data from DbTable", sc);

                SqliteDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Data.Add(dr.GetString(0));
                }

                sc.Close();
            }
        }
    }
}