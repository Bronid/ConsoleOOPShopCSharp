using ConsoleOOPShopCSharp.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class Category : ISpacious<Product>
    {
        private string categoryName = "";
        private int categoryId = 0;
        private List<Product> products = new List<Product>();

        public Category(string categoryName, int categoryId)
        {
            this.categoryName = categoryName;
            this.categoryId = categoryId;
        }

        new public void ToString() => Console.WriteLine($"Name: {categoryName}");

        public void Add(Product a) => products.Add(a);

        public void Remove(int id) => products.RemoveAt(id);
        public string getProductNameByIndex(int id) => products[id].ProductName;

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

        public string getName() => categoryName;

        public int getCategoryId() => categoryId;

    }
}