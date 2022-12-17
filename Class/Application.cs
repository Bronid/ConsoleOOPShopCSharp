using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    internal class Application
    {
        void Start()
        {
            Console.WriteLine("Welcome to ConsoleShopApplication!");
            //There are we need add init functions
        }

        void printLine()
        {
            Console.WriteLine("-------------------------------------------");
        }
        void ShowMenu()
        {
            Console.WriteLine("Options: ");
            printLine();
            Console.WriteLine("1. Add Product");
            printLine();
            Console.WriteLine("2. Add Category");
            printLine();
            Console.WriteLine("3. Remove Product");
            printLine();
            Console.WriteLine("4. Remove Category");
            printLine();
            Console.WriteLine("5. Show Product");
            printLine();
            Console.WriteLine("6. Show Category");

        }
    }
}
