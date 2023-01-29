using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class Product : IComparable
    {
        private string productName = "";
        private float productPrice = 0;

        public Product(string productName, float productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
        }
        new public void ToString() => Console.WriteLine($"Name: {productName}  Price: {productPrice}");
        public int CompareTo(object? o)
        {
            if (o is Product product) return productPrice.CompareTo(product.productPrice);
            else throw new ArgumentException("Incorrect object");
        }
        public string GetProductName() { return productName; }
        public float GetProductPrice() { return productPrice; }

    }
}