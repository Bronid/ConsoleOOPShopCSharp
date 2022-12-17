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
        Assortment assortment = new Assortment();
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
            Console.WriteLine("5. Show Products");
            printLine();
            Console.WriteLine("6. Show Categories");
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
                case 0: isStart = false; break;
                case 1:
                    assortment.printAssortment();
                    Console.WriteLine("Where to add: ");
                    int index = int.Parse(Console.ReadLine());
                    Product p = new Product();
                    p.CreateProduct();
                    assortment.categories[index-1].addProduct(p);
                    break;

                case 2:
                    Category c = new Category();
                    c.createCategory();
                    assortment.addCategory(c);
                    break;

                case 3:
                    assortment.printAssortment();
                    Console.WriteLine("Where to delete: ");
                    index = int.Parse(Console.ReadLine());
                    assortment.categories[index-1].removeProduct();
                    break;
                case 4:
                    assortment.printAssortment();
                    Console.WriteLine("What to delete: ");
                    index = int.Parse(Console.ReadLine());
                    assortment.removeCategory(index - 1);
                    break;
                case 5:
                    assortment.printAssortment();
                    Console.WriteLine("What category: ");
                    index = int.Parse(Console.ReadLine());
                    assortment.categories[index - 1].printCategory();
                    break;
                case 6:
                    assortment.printAssortment();
                    break;
            }

        }
    }
}
