using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class Product
    {
        private string productName = "";
        private float productPrice = 0;

        public Product(string productName, float productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
        }
        new public void ToString() => Console.WriteLine($"Name: {productName}  Price: {productPrice}");

        public string ProductName { get { return productName; } }

    }
}