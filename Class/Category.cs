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

        public void addProduct(Product a)
        {
            products.Add(a);
        }

        new public void Print() => Console.WriteLine($"Name: {categoryName}");

        public void printCategory()
        {
            Console.WriteLine($"List of {categoryName}:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write("\n" + (i+1) + ". ");
                products[i].Print();
            }
        }

    }
}
