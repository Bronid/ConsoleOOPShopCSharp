using ConsoleOOPShopCSharp.Class;

//test
namespace ConsoleOOPShopCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();
            Product p = new Product("Coca-Cola", 9.50f);
            Product p2 = new Product("Sprite", 9);
            Category drinks = new Category("Drinks");
            drinks.addProduct(p);
            drinks.addProduct(p2);
            drinks.printCategory();

            application.Start();
            application.ShowMenu();
        }
    }
}