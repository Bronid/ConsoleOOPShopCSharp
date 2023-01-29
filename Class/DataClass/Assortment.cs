using ConsoleOOPShopCSharp.Class.Enumaratos;
using ConsoleOOPShopCSharp.Class.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class Assortment : ISpacious<Category>, IEnumerable
    {
        public List<Category> categories = new List<Category>();

        public Assortment()
        {
        }
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        public CategoryEnum GetEnumerator()
        {
            return new CategoryEnum(categories);
        }

        public void Add(Category obj) => categories.Add(obj);

        public void PrintListInfo()
        {
            Console.WriteLine("\nAssortment:");
            for (int i = 0; i < categories.Count; i++)
            {
                Console.Write("\n" + (i + 1) + ". ");
                categories[i].ToString();
            }
        }

    }
}