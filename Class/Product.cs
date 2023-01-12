using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    public class Product
    {
        private string productName = "";
        private float productPrice = 0;

        public Product(string productName, float productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            Console.WriteLine($"New product {this.productName} with price {this.productPrice}zl added! :3");
        }
        new public void ToString() => Console.WriteLine($"Name: {productName}  Price: {productPrice}");

    }
}