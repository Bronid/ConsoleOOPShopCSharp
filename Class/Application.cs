using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleOOPShopCSharp.Class;

namespace ConsoleOOPShopCSharp.Class
{
    public class Application
    {
        public bool isStart = false;
        public void Start()
        {
            isStart = true;
            Console.WriteLine("Welcome to ConsoleShopApplication!");
            //There are we need add init functions
        }

        internal void printLine()
        {
            Console.WriteLine("-------------------------------------------");
        }
        public void ShowMenu()
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
            printLine();
            Console.WriteLine("7. Filter Products");
            printLine();
            Console.WriteLine("8. Filter Categories");
            printLine();
            Console.WriteLine("0. EXIT\n");
            Console.WriteLine("Please choose a number from 0 to 8");
        }

        public void Select()
        {
            int SelectedNum = int.Parse(Console.ReadLine());
            if (SelectedNum < 0 || SelectedNum > 8) Console.WriteLine("Please choose a number from 0 to 8");
            switch(SelectedNum)
            {
                case 1:
                    Product test = new Product();
                    test.CreateProduct();
                break;
            }

        }
    }
}
