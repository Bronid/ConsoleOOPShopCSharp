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
        public void createCategory()
        {
            Console.WriteLine("Please write the name of new category");
            this.categoryName = Console.ReadLine();
            Console.WriteLine($"New category {this.categoryName} added! :3");
        }
        new public void Print() => Console.WriteLine($"Name: {categoryName}");

        public void addProduct(Product a)
        {
            products.Add(a);
        }

        public void printCategory()
        {
            Console.WriteLine($"List of {categoryName}:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                products[i].Print();
            }
        }

        public void removeProduct()
        {

            if (products.Count <= 0)
            {
                Console.WriteLine("We have nothing to delete, first you need to add products!");
                return;
            }
            printCategory();
            Console.WriteLine("What to delete: ");
            int index = NumTester(Console.ReadLine());
            if (index == -404) return;
            products.RemoveAt(index - 1);

        }

    }
}