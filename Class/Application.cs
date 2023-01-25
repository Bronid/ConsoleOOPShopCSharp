using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleOOPShopCSharp.Class.DataClass;

namespace ConsoleOOPShopCSharp.Class
{
    public class Application
    {
        float startUserBalance = 100;
        ExceptionHelper e = new ExceptionHelper();
        const string connectionString = "Data Source=database.db; Version=3; New=True; Compress=True;";
        Database db = new Database(connectionString);
        public bool isStart = false;
        Assortment assortment = new Assortment();
        List<User> users = new List<User>(); //todo
        public void Start()
        {
            isStart = true;
            db.Connect();
            db.executeQuery("CREATE TABLE IF NOT EXISTS Products (productId INTEGER PRIMARY KEY, productName TEXT, productPrice REAL, categoryId INTEGER)");
            db.executeQuery("CREATE TABLE IF NOT EXISTS Categories (categoryId INTEGER PRIMARY KEY, categoryName TEXT)");
            db.executeQuery("CREATE TABLE IF NOT EXISTS Users (userId INTEGER PRIMARY KEY, Login TEXT, Password TEXT, Balance REAL, Permissions TEXT)");
            db.syncData(out assortment);
            Console.WriteLine("Welcome to ConsoleShopApplication!");
            //StartMenu();
        }
        private void printLine()
        {
            Console.WriteLine("-------------------------------------------");
        }
        private void ShowMenu()
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
            Console.WriteLine("0. EXIT\n");
            Console.WriteLine("Please choose a number:");
        }
        private void Login()
        {
            string login = "";
            string pass = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPlease authorize yourself(to back print '0')");
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                if (login == "0") StartMenu();
                if (db.isUserExist(login)) break;
                else Console.WriteLine("User is not exists!");
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPlease authorize yourself(to back print '0')");
                Console.WriteLine("Password: ");
                pass = Console.ReadLine();
                if (pass == "0") StartMenu();
                if (db.isCorrectPassword(login, pass)) break;
                else Console.WriteLine("Incorrect password!");
            }

            AuthorizeUser(login);
        }
        private void Register()
        {
            string login = "";
            string pass = "";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPlease register(to back print '0')");
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                if (login == "0") StartMenu();
                if (!db.isUserExist(login)) break;
                else Console.WriteLine("User with this login already exists!");
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPlease register(to back print '0')");
                Console.WriteLine("Password: ");
                pass = Console.ReadLine();
                if (pass == "0") StartMenu();
                break;
            }
            Console.Clear();
            db.executeQuery($"INSERT INTO Users (Login, Password, Balance, Permissions) VALUES (\"{login}\", \"{pass}\", {startUserBalance}, \"User\")");
            Console.WriteLine("New user added!");
        }
        public void AuthorizeUser(string login)
        {

        }
        private void StartMenu()
        {
            while (isStart)
            {
                Console.WriteLine("\nOptions: ");
                printLine();
                Console.WriteLine("1. Login");
                printLine();
                Console.WriteLine("2. Register");
                printLine();
                Console.WriteLine("0. EXIT\n");
                Console.WriteLine("Please choose a number:");
                int SelectedNum = e.NumTester();
                if (SelectedNum < 0 || SelectedNum > 2) Console.WriteLine("Please choose a number from 0 to 2");
                switch (SelectedNum)
                {
                    case 0: Console.Clear(); isStart = false; break;
                    case 1: Login(); break;
                    case 2: Register(); break;
                }
            }
        }


        public void pSettings()
        {
            ShowMenu();
            int SelectedNum = e.NumTester();
            if (SelectedNum < 0 || SelectedNum > 6) Console.WriteLine("Please choose a number from 0 to 6");
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
                    int index = e.NumTesterCategories(assortment.categories.Count);
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
                    int index2 = e.NumTester();
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