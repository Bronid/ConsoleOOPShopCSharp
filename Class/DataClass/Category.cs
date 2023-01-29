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
    public class Category : ISpacious<Product>, IEnumerable, IComparable
    {
        private string categoryName = "";
        private int categoryId = 0;
        private List<Product> products = new List<Product>();

        public Category(string categoryName, int categoryId)
        {
            this.categoryName = categoryName;
            this.categoryId = categoryId;
        }
        IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

        public ProductEnum GetEnumerator()
        {
            return new ProductEnum(products);
        }

        public int CompareTo(object? o)
        {
            if (o is Category category) return categoryName.CompareTo(category.categoryName);
            else throw new ArgumentException("Incorrect object");
        }

        new public void ToString() => Console.WriteLine($"Name: {categoryName}");

        public void Add(Product obj) => products.Add(obj);

        public void PrintListInfo()
        {
            Console.WriteLine($"List of {categoryName}:");
            for (int i = 0; i < products.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                products[i].ToString();
            }
        }
        public Product getProductByIndex(int index) => products[index];

        public List<Product> getProductList() => products;
        
        public int GetListCount() => products.Count;

        public string getName() => categoryName;

        public int getCategoryId() => categoryId;

    }
}