using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleOOPShopCSharp.Class.DataClass;
using System.Configuration;
using System.Reflection;

namespace ConsoleOOPShopCSharp.Class
{
    public static class Application
    {
        static float startUserBalance = 100;
        static ExceptionHelper e = new ExceptionHelper();
        const string connectionString = "Data Source=database.db; Version=3; New=True; Compress=True;";
        static Database db = new Database(connectionString);
        private static bool isStart = false;
        private static bool isAuthorized = false;
        static Assortment assortment = new Assortment();
        static List<User> users = new List<User>();
        static User currentUser = null;
        public static void Start()
        {
            isStart = true;
            db.Connect();
            db.executeQuery("CREATE TABLE IF NOT EXISTS Products (productId INTEGER PRIMARY KEY, productName TEXT, productPrice REAL, categoryId INTEGER)");
            db.executeQuery("CREATE TABLE IF NOT EXISTS Categories (categoryId INTEGER PRIMARY KEY, categoryName TEXT)");
            db.executeQuery("CREATE TABLE IF NOT EXISTS Users (Login TEXT NOT NULL, Password TEXT NOT NULL, Balance REAL, Permissions TEXT)");
            db.executeQuery("CREATE TABLE IF NOT EXISTS Orders (orderId INTEGER PRIMARY KEY, userLogin TEXT, productName TEXT, productPrice REAL, Count INTEGER, orderDate DATE)");
            db.syncData(out assortment, out users);
            Console.WriteLine("Welcome to ConsoleShopApplication!");
            LoginMenu();
        }
        private static void printLine()
        {
            Console.WriteLine("-------------------------------------------");
        }
        private static void Login()
        {
            string login = "";
            string pass = "";

            while (true)
            {
                Console.WriteLine("\nPlease authorize yourself(to back print '0')");
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                if (login == "0") LoginMenu();
                if (db.isUserExist(login)) break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("User is not exists!");
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPlease authorize yourself(to back print '0')");
                Console.WriteLine("Password: ");
                pass = Console.ReadLine();
                if (pass == "0") LoginMenu();
                if (db.isCorrectPassword(login, pass)) break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect password!");
                }
            }

            AuthorizeUser(login);
        }
        private static void Register()
        {
            string login = "";
            string pass = "";

            while (true)
            {
                Console.WriteLine("\nPlease register(to back print '0')");
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                if (login == "0") LoginMenu();
                if (!db.isUserExist(login)) break;
                else
                {
                    Console.Clear();
                    Console.WriteLine("User with this login already exists!");
                }
            }
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nPlease register(to back print '0')");
                Console.WriteLine("Password: ");
                pass = Console.ReadLine();
                if (pass == "0") LoginMenu();
                break;
            }
            Console.Clear();
            db.executeQuery($"INSERT INTO Users (Login, Password, Balance, Permissions) VALUES (\"{login}\", \"{pass}\", {startUserBalance}, \"User\")");
            db.syncData(out assortment, out users);
            Console.WriteLine("New user added!");
        }
        private static void AuthorizeUser(string login)
        {
            currentUser = users.Find(user => user.GetLogin() == login);
            isAuthorized = true;
        }
        private static void LoginMenu()
        {
            while (isStart)
            {
                if (!isAuthorized)
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
                    if (SelectedNum < 0 || SelectedNum > 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Please choose a number from 0 to 2");
                    }
                    switch (SelectedNum)
                    {
                        case 0: Console.Clear(); isStart = false; break;
                        case 1: Login(); break;
                        case 2: Register(); break;
                    }
                }
                else MainMenu();
            }
        }
        private static void MainMenu()
        {
            Console.WriteLine($"Hello, {currentUser.GetLogin()}!");
            Console.WriteLine($"Your balance is: {currentUser.GetBalance()}");
            Console.WriteLine("\nOptions: ");
            printLine();
            Console.WriteLine("1. Shop");
            printLine();
            Console.WriteLine("2. Show order history");
            printLine();
            Console.WriteLine("3. Logout");
            printLine();
            Console.WriteLine("4. Options");
            printLine();
            Console.WriteLine("0. EXIT");
            int SelectedNum = e.NumTester();
            if (SelectedNum < 0 || SelectedNum > 4)
            {
                Console.Clear();
                Console.WriteLine("Please choose a number from 0 to 4");
            }
            switch (SelectedNum)
            {
                case 0: Console.Clear(); isStart = false; break;
                case 1:
                    Filter();
                    break;
                case 2:
                    Console.Clear();
                    currentUser.PrintListInfo();
                    break;
                case 3:
                    currentUser = null;
                    isAuthorized = false;
                    Console.Clear();
                    break;
                case 4:
                    SettingsMenu();
                    break;
            }
        }
        private static void OrderMenu(Assortment newAsortment)
        {
            Console.Clear();
            if (newAsortment.categories.Count <= 0)
            {
                Console.Clear();
                Console.WriteLine("We have nothing to show you!");
                return;
            }
            newAsortment.PrintListInfo();
            Console.WriteLine("What category:\n0. EXIT");
            int indexCategory = e.NumTesterCategories(newAsortment) - 1;
            if (indexCategory == -1) return;
            if (newAsortment.categories[indexCategory].GetListCount() <= 0)
            {
                Console.WriteLine("We have nothing to show you, first you need to add a product!");
                return;
            }
            newAsortment.categories[indexCategory].PrintListInfo();
            Console.WriteLine("What product you want to buy: ");
            int indexProduct = e.NumTesterProducts(newAsortment, indexCategory) - 1;
            Product productBuy = newAsortment.categories[indexCategory].getProductByIndex(indexProduct);
            Console.WriteLine("Count: ");
            int productCount = e.NumTester();
            if (currentUser.GetBalance() - (productBuy.GetProductPrice() * productCount) >= 0)
            { 
                db.executeQuery($"UPDATE Users SET Balance = {currentUser.GetBalance() - (productBuy.GetProductPrice() * productCount)} WHERE Login = \"{currentUser.GetLogin()}\"");
                DateTime time = DateTime.Now;
                db.executeQuery($"INSERT INTO Orders(userLogin, productName, productPrice, Count, orderDate)" +
                    $"VALUES(\"{currentUser.GetLogin()}\", \"{productBuy.GetProductName()}\", {productBuy.GetProductPrice()}, {productCount}, " +
                    $"\"{time.Year}-{time.Month}-{time.Day} {time.Hour}:{time.Minute}:{time.Second}\")");
                db.syncData(out assortment, out users);
                AuthorizeUser(currentUser.GetLogin());
            }
            else
            {
                Console.WriteLine($"You have not enough money\n");
            }
        }
        private static void Filter()
        {
            Assortment sortedAssortment = assortment;
            while (true)
            {
                if (assortment.categories.Count <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("We have nothing to show you, first you need to add category!");
                    return;
                }
                Console.WriteLine("\nOptions: ");
                printLine();
                Console.WriteLine("1. Filter Categories by name");
                printLine();
                Console.WriteLine("2. Filter Products by name");
                printLine();
                Console.WriteLine("3. Filter Products by price");
                printLine();
                Console.WriteLine("4. Sort Categories by name");
                printLine();
                Console.WriteLine("5. Sort Products by price");
                printLine();
                Console.WriteLine("6. Shop");
                printLine();
                Console.WriteLine("0. EXIT");
                int SelectedNum = e.NumTester();
                if (SelectedNum < 0 || SelectedNum > 6)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a number from 0 to 7");
                }
                switch (SelectedNum){
                    case 0: return;
                    case 6: OrderMenu(sortedAssortment); break;
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Write first lettes to filter Categories by name(or write 0 to return): ");
                        string categoryFilter = Console.ReadLine();
                        if (categoryFilter != "0")
                        {
                            Assortment tempAssortment = new Assortment();
                            foreach (Category category in sortedAssortment.categories)
                            {
                                if (category.getName().StartsWith(categoryFilter))
                                    tempAssortment.categories.Add(category);
                            }
                            sortedAssortment = tempAssortment;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Write first lettes to filter Products by name(or write 0 to skip): ");
                        string productsFilter = Console.ReadLine();
                        if (productsFilter != "0")
                        {
                            Assortment tempAssortment = new Assortment();
                            int i = 0;
                            foreach (Category category in sortedAssortment.categories)
                            {
                                foreach(Product product in category)
                                {
                                    tempAssortment.categories.Add(category);
                                    if (product.GetProductName().StartsWith(productsFilter))
                                    {
                                        tempAssortment.categories[i].Add(product);
                                        i++;
                                    }
                                }
                            }
                            sortedAssortment = tempAssortment;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Write min price to filter Products by price(write 0 to skip): ");
                        float productsFilterMin = e.NumTester();
                        if (productsFilterMin != 0)
                        {
                            Assortment tempAssortment = new Assortment();
                            foreach (Category category in sortedAssortment.categories)
                            {
                                Category tempCategory = new Category(category.getName(), category.getCategoryId());
                                foreach (Product product in category)
                                {
                                    if (product.GetProductPrice() >= productsFilterMin)
                                    {
                                        tempCategory.Add(product);
                                    }
                                }
                                tempAssortment.Add(tempCategory);
                            }
                            sortedAssortment = tempAssortment;
                        }

                        Console.WriteLine("Write max price to filter Products by price(write 0 to skip): ");
                        float productsFilterMax = e.NumTester();
                        if (productsFilterMax != 0)
                        {
                            Assortment tempAssortment = new Assortment();
                            foreach (Category category in sortedAssortment.categories)
                            {
                                Category tempCategory = new Category(category.getName(), category.getCategoryId());
                                foreach (Product product in category)
                                {
                                    if (product.GetProductPrice() <= productsFilterMax)
                                    {
                                        tempCategory.Add(product);
                                    }
                                }
                                tempAssortment.Add(tempCategory);
                            }
                            sortedAssortment = tempAssortment;
                        }
                        break;
                    case 4:
                        sortedAssortment.categories.Sort();
                        Console.Clear();
                        Console.WriteLine("Sort done!");
                        break;
                    case 5:
                        for (int i = 0; i < sortedAssortment.categories.Count; i++)
                        {
                            sortedAssortment.categories[i].getProductList().Sort();
                        }
                        Console.Clear();
                        Console.WriteLine("Sort done!");
                        break;
                }
            }
        }
        private static void SettingsMenu()
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
                    int index = e.NumTesterCategories(assortment) - 1;
                    Console.WriteLine("Please write the name of new product");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Please write the price of new product");
                    int productPrice = e.NumTesterPrice();
                    db.executeQuery($"INSERT INTO Products (productName, productPrice, categoryId) VALUES (\"{productName}\", {productPrice}, {assortment.categories[index].getCategoryId()});");
                    Console.WriteLine($"New product {productName} with price {productPrice}zl added! :3");
                    db.syncData(out assortment, out users);
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Please write the name of new category");
                    string categoryName = Console.ReadLine();
                    db.executeQuery($"INSERT INTO Categories (categoryName) VALUES (\"{categoryName}\");");
                    Console.WriteLine($"New category {categoryName} added! :3");
                    db.syncData(out assortment, out users);
                    break;
                    
                case 3:
                    Console.Clear();
                    assortment.PrintListInfo();
                    Console.WriteLine("Where to delete: ");
                    index = e.NumTesterCategories(assortment) - 1;
                    if (assortment.categories[index].GetListCount() <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add products!");
                        break;
                    }
                    assortment.categories[index].PrintListInfo();
                    Console.WriteLine("What to delete: ");
                    int index2 = e.NumTesterProducts(assortment, index) - 1;
                    db.executeQuery($"DELETE FROM Products WHERE categoryId = {assortment.categories[index].getCategoryId()} AND productName = \"{assortment.categories[index].getProductByIndex(index2).GetProductName()}\"; ");
                    Console.WriteLine($"Product {assortment.categories[index].getProductByIndex(index2).GetProductName()} removed!");
                    db.syncData(out assortment, out users);
                    break;
                    
                case 4:
                    Console.Clear();
                    if (assortment.categories.Count <= 0)
                    {
                        Console.WriteLine("We have nothing to delete, first you need to add category!");
                    }
                    assortment.PrintListInfo();
                    Console.WriteLine("What to delete: ");
                    index = e.NumTesterCategories(assortment) - 1;
                    db.executeQuery($"DELETE FROM Categories WHERE categoryId = {assortment.categories[index].getCategoryId()};");
                    db.executeQuery($"DELETE FROM Products WHERE categoryId = {assortment.categories[index].getCategoryId()};");
                    Console.WriteLine($"Category {assortment.categories[index].getName()} removed!");
                    db.syncData(out assortment, out users);
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
                    index = e.NumTesterCategories(assortment) - 1;
                    assortment.categories[index].PrintListInfo();
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