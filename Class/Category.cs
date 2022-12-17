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
        private List<Product> products = new List<Product>();


        public Category()
        {
        }
        public Category(string categoryName)
        {
            this.categoryName = categoryName;
        }

        void addProduct(Product a)
        {
            products.Add(a);
        }

        void printCategory()
        {
            for (int i = 0; i < products.Count; i++)
            {
                Console.WriteLine(i + ". ");
                products[i].Print();
            }
        }

    }
}
