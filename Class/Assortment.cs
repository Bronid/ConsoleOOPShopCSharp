using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    public class Assortment : ISpacious<Category>
    {
        public List<Category> categories = new List<Category>();

        public Assortment()
        {
        }

        public void Add(Category c) => categories.Add(c);

        public void Remove(int index) => categories.RemoveAt(index);

        public void PrintListInfo()
        {
            Console.WriteLine("\nAssortment:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.Write("\n" + (i + 1) + ". ");
                categories[i].Print();
            }
        }

    }
}