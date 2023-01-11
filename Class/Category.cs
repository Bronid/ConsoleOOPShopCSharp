using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    public class Category : ISpacious<Product>
    {
        private string categoryName = "";
        private List<Product> products = new List<Product>();

        public Category()
        {
        }
       
        public void Create()
        {
            Console.WriteLine("Please write the name of new category");
            this.categoryName = Console.ReadLine();
            Console.WriteLine($"New category {this.categoryName} added! :3");
        }
        new public void ToString() => Console.WriteLine($"Name: {categoryName}");

        public void Add(Product a)
        {
            products.Add(a);
        }

        public void Remove(int id)
        {
            //Перенести в Application Select()
            if (products.Count <= 0)
            {
                Console.WriteLine("We have nothing to delete, first you need to add products!");
                return;
            }
            ToString();
            Console.WriteLine("What to delete: ");
            int index = NumTester(Console.ReadLine());
            if (index == -404) return;
            products.RemoveAt(index - 1);

        }

        public void PrintListInfo()
        {
            Console.WriteLine($"List of {categoryName}:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                products[i].Print();
            }
        }

    }
}