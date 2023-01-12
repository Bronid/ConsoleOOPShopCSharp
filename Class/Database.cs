using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;

namespace ConsoleOOPShopCSharp.Class
{
    public class Database
    {
        SQLiteConnection sqlite_conn;
        public Database(string connectionString)
        {
            this.sqlite_conn = new SQLiteConnection(connectionString);
            
        }

        public void Connect()
        {
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                sqlite_conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void executeQuery(string query)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = query;
            sqlite_cmd.ExecuteNonQuery();
        }
    }
}
