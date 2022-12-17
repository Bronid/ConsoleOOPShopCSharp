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

            public void Print() => Console.WriteLine($"Name: {productName}  Price: {productPrice}\n");


        }
}
