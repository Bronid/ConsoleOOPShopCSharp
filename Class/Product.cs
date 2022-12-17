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

            public Product()
            {
            }
            public Product(string productName, float productPrice)
            {
                this.productName = productName;
                this.productPrice = productPrice;
            }

            public void Print() => Console.WriteLine($"Name: {productName}  Price: {productPrice}");

            public void CreateProduct()
            {
                Console.WriteLine("Please write the name of new product");
                this.productName = Console.ReadLine();
                Console.WriteLine("Please write the price of new product");
                this.productPrice = float.Parse(Console.ReadLine());
                Console.WriteLine($"New product {this.productName} with price {this.productPrice}zl added! :3");
            }

        }
}
