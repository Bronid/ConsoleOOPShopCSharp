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

        public void syncData(out Assortment assortment)
        {
            Assortment tempassortment = new Assortment();

            string stm = "SELECT * FROM Categories";
            var cmd = new SQLiteCommand(stm, sqlite_conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();

            List<int> idList = new List<int>();

            while (rdr.Read())
            {
                Category temp = new Category(rdr.GetString(1), rdr.GetInt32(0));
                tempassortment.Add(temp);
                idList.Add(rdr.GetInt32(0));
            }

            foreach (int id in idList)
            {
                stm = $"SELECT * FROM Products WHERE categoryId = {id}";
                cmd = new SQLiteCommand(stm, sqlite_conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Product temp = new Product(rdr.GetString(1), rdr.GetFloat(2));
                    tempassortment.categories[idList.IndexOf(id)].Add(temp);
                }
            }
            assortment = tempassortment;
            Console.WriteLine("Data synchronized");
        }
    }
}
