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
        ExceptionHelper e = new ExceptionHelper();
        const string connectionString = "Data Source=database.db; Version=3; New=True; Compress=True;";
        Database db = new Database(connectionString);
        public bool isStart = false;
        Assortment assortment = new Assortment();
        public void Start()
        {
            isStart = true;
            db.Connect();
            db.executeQuery("CREATE TABLE IF NOT EXISTS Products (productId INTEGER PRIMARY KEY, productName TEXT, productPrice REAL, categoryId INTEGER)");
            db.executeQuery("CREATE TABLE IF NOT EXISTS Categories (categoryId INTEGER PRIMARY KEY, categoryName TEXT)");
            db.syncData(out assortment);
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



        public void Select()
        {
            int SelectedNum = e.NumTester();
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
                    index = e.NumTesterCategories(assortment.categories.Count);
                    Console.WriteLine("Please write the name of new product");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Please write the price of new product");
                    int productPrice = e.NumTester();
                    db.executeQuery($"INSERT INTO Products (productName, productPrice, categoryId) VALUES (\"{productName}\", {productPrice}, {assortment.categories[index - 1].getCategoryId()});");
                    Console.WriteLine($"New product {productName} with price {productPrice}zl added! :3");
                    db.syncData(out assortment);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Please write the name of new category");
                    string categoryName = Console.ReadLine();
                    db.executeQuery($"INSERT INTO Categories (categoryName) VALUES (\"{categoryName}\");");
                    Console.WriteLine($"New category {categoryName} added! :3");
                    db.syncData(out assortment);
                    break;
                    
                case 3:
                    Console.Clear();
                    assortment.PrintListInfo();
                    Console.WriteLine("Where to delete: ");
                    index = e.NumTesterCategories(assortment.categories.Count);
                    if (assortment.categories[index - 1].GetListCount() <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add products!");
                        break;
                    }
                    assortment.categories[index - 1].PrintListInfo();
                    Console.WriteLine("What to delete: ");
                    index2 = e.NumTester();
                    db.executeQuery($"DELETE FROM Products WHERE categoryId = {assortment.categories[index - 1].getCategoryId()} AND productName = \"{assortment.categories[index - 1].getProductNameByIndex(index2 - 1)}\"; ");
                    Console.WriteLine($"Product {assortment.categories[index - 1].getProductNameByIndex(index2 - 1)} removed!");
                    db.syncData(out assortment);
                    break;
                    
                case 4:
                    Console.Clear();
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add category!");
                    }
                    assortment.PrintListInfo();
                    Console.WriteLine("What to delete: ");
                    index = e.NumTesterCategories(assortment.categories.Count);
                    db.executeQuery($"DELETE FROM Categories WHERE categoryId = {assortment.categories[index - 1].getCategoryId()};");
                    db.executeQuery($"DELETE FROM Products WHERE categoryId = {assortment.categories[index - 1].getCategoryId()};");
                    Console.WriteLine($"Category {assortment.categories[index - 1].getName()} removed!");
                    db.syncData(out assortment);
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
                    index = e.NumTesterCategories(assortment.categories.Count);
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