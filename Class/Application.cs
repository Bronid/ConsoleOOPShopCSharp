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
        string connectionString = "Data Source=database.db; Version=3; New=True; Compress=True;";
        public bool isStart = false;
        Assortment assortment = new Assortment();
        public void Start()
        {
            isStart = true;
            Database db = new Database(connectionString);
            db.Connect();
            //db.executeQuery("CREATE TABLE Products (productId INTEGER PRIMARY KEY, productName TEXT, productPrice REAL, categoryId INTEGER)");
            //db.executeQuery("CREATE TABLE Categories (categoryId INTEGER PRIMARY KEY, categoryName TEXT)");
            Console.WriteLine("Welcome to ConsoleShopApplication!");
        }

        internal void printLine()
        {
            Console.WriteLine("-------------------------------------------");
        }
        public void ShowMenu()
        {
            Console.WriteLine("\nOptions: ");
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
            int index2 = -1;
            switch (SelectedNum)
            {

                case 0: Console.Clear(); isStart = false; break;
                
                case 1:
                    Console.Clear();
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("First you need to add category!");
                        break;
                    }
                    assortment.PrintListInfo();
                    Console.WriteLine("Where to add: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    Console.WriteLine("Please write the name of new product");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Please write the price of new product");
                    int productPrice = NumTester(Console.ReadLine());
                    if (productPrice == -404) return;
                    Product p = new Product(productName, productPrice);
                    assortment.categories[index - 1].Add(p);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Please write the name of new category");
                    string categoryName = Console.ReadLine();
                    Category c = new Category(categoryName);
                    assortment.Add(c);
                    break;
                    
                case 3:
                    Console.Clear();
                    assortment.PrintListInfo();
                    Console.WriteLine("Where to delete: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }

                    if (assortment.categories[index - 1].GetListCount() <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add products!");
                        break;
                    }
                    assortment.categories[index - 1].PrintListInfo();
                    Console.WriteLine("What to delete: ");
                    index2 = NumTester(Console.ReadLine());
                    if (index2 == -404) break;
                    assortment.categories[index - 1].Remove(index2);
                    break;
                    
                case 4:
                    Console.Clear();
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add category!");
                    }
                    assortment.PrintListInfo();
                    Console.WriteLine("What to delete: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    assortment.Remove(index);
                    break;
                    
                case 5:
                    Console.Clear();
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to show you, first you need to add category!");
                        break;
                    }
                    assortment.PrintListInfo();
                    Console.WriteLine("What category: ");
                    index = NumTester(Console.ReadLine());
                    if (index == -404) break;
                    if (index < 0 || index > assortment.categories.Count)
                    {
                        Console.WriteLine($"There are only {assortment.categories.Count} categories");
                        break;
                    }
                    assortment.categories[index - 1].PrintListInfo();
                    break;
                    
                case 6:
                    Console.Clear();
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to show you, first you need to add category!");
                        break;
                    }
                    else
                    {
                        assortment.PrintListInfo();
                    }
                    break;
            }
        }
    }
}