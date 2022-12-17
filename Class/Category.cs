using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    public class Category : Product
    {
        private string categoryName = "";
        List<Product> products = new List<Product>();

        public Category()
        {
        }
        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }
    }
}
