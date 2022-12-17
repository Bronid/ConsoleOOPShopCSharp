using System;
using System.Collections.Generic;
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
            Console.WriteLine("Please choose a number:");
        }

        public int NumTester(string ForTest)
        {
            int index = 0;
            try
            {
                index = int.Parse(ForTest);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please write a NUMBER");
                return -404;

            }
            return index;
        }

        public void Select()
        {
            int SelectedNum = NumTester(Console.ReadLine());
            if (SelectedNum == -404) return;
            if (SelectedNum < 0 || SelectedNum > 8) Console.WriteLine("Please choose a number from 0 to 8");
            int index = -1;
            switch (SelectedNum)
            {

                case 0: isStart = false; break;
                
                case 1:
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("First you need to add category!");
                        break;
                    }
                    assortment.printAssortment();
                    Console.WriteLine("Where to add: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    Product p = new Product();
                    p.CreateProduct();
                    assortment.categories[index - 1].addProduct(p);
                    break;

                case 2:
                    Category c = new Category();
                    c.createCategory();
                    assortment.addCategory(c);
                    break;
                    
                case 3:
                    assortment.printAssortment();
                    Console.WriteLine("Where to delete: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    assortment.categories[index - 1].removeProduct();
                    break;
                    
                case 4:
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add category!");
                    }
                    assortment.printAssortment();
                    Console.WriteLine("What to delete: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    assortment.removeCategory(index - 1);
                    break;
                    
                case 5:
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to show you, first you need to add category!");
                        break;
                    }
                    assortment.printAssortment();
                    Console.WriteLine("What category: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    assortment.categories[index - 1].printCategory();
                    break;
                    
                case 6:
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to show you, first you need to add category!");
                        break;
                    }
                    else
                    {
                        assortment.printAssortment();
                    }
                    break;
            }
        }
    }
}