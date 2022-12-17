using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    public class Assortment : Category
    {
        private List<Category> categories = new List<Category>();
        
        public Assortment()
        {
        }
        public void addCategory(Category c)
        {
            categories.Add(c);
        }

        public void printAssortment()
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
