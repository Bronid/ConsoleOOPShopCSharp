using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data.Entity;
using ConsoleOOPShopCSharp.Class.DataClass;

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

        public bool isUserExist(string login)
        {
            string stm = $"SELECT * FROM Users WHERE Login = \"{login}\"";
            var cmd = new SQLiteCommand(stm, sqlite_conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) return true;
            else return false;
        }

        public bool isCorrectPassword(string login, string pass)
        {
            string stm = $"SELECT * FROM Users WHERE Login = \"{login}\"";
            var cmd = new SQLiteCommand(stm, sqlite_conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.GetString(1) == pass) return true;
            else return false;
        }

        public void syncData(out Assortment assortment, out List<User> users)
        {
            Assortment tempassortment = new Assortment();
            List<User> tempusers = new List<User>();

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

            stm = "SELECT * FROM Users";
            cmd = new SQLiteCommand(stm, sqlite_conn);
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                User temp = new User(rdr.GetString(0), rdr.GetString(1), rdr.GetFloat(2), rdr.GetString(3));
                tempusers.Add(temp);
            }

            assortment = tempassortment;
            users = tempusers;
            Console.WriteLine("Data synchronized");
        }
    }
}
