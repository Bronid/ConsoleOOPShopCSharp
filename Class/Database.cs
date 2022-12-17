using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleOOPShopCSharp.Class
{
    public class Database
    {
        private string connectionString = "";
        Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Connect()
        {
        }

        public void executeQuery(string query)
        {
            
        }
    }
}
