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

        public Category(string categoryName)
        {
            this.categoryName = categoryName;
            Console.WriteLine($"New category {this.categoryName} added! :3");
        }
      
        new public void ToString() => Console.WriteLine($"Name: {categoryName}");

        public void Add(Product a) => products.Add(a);
        
        public void Remove(int id) => products.RemoveAt(id);

        public void PrintListInfo()
        {
            Console.WriteLine($"List of {categoryName}:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                products[i].ToString();
            }
        }
        public int GetListCount()
        {
            return products.Count;
        }

    }
}