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

        public int NumTester(string ForTest)
        {
            int index = 0;
            try
            {
                index = int.Parse(ForTest);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please write a number");
                return -404;

            }
            return index;
        }

        public void CreateProduct()
        {
            Console.WriteLine("Please write the name of new product");
            string productName = Console.ReadLine();
            Console.WriteLine("Please write the price of new product");
            int productPrice = NumTester(Console.ReadLine());
            if (productPrice == -404) return;
            this.productPrice = productPrice;
            this.productName = productName;
            Console.WriteLine($"New product {this.productName} with price {this.productPrice}zl added! :3");
        }

    }
}