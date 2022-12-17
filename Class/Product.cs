using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleOOPShopCSharp.Class
    {
        public class Product
        {
            private string name = "";
            private float price = 0;

            public Product()
            {
            }
            public Product(string name, float price)
            {
                this.name = name;
                this.price = price;
            }

            public void Print() => Console.WriteLine($"Name: {name}  Price: {price}");


        }
    }
}
