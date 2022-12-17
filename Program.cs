using ConsoleOOPShopCSharp.Class;

//test
namespace ConsoleOOPShopCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assortment assortment = new Assortment();
            Application application = new Application();
            Product p = new Product("Coca-Cola", 9.50f);
            Product p2 = new Product("Sprite", 9);
            Category drinks = new Category("Drinks");
            assortment.addCategory(drinks);
            drinks.addProduct(p);
            drinks.addProduct(p2);
            drinks.printCategory();
            assortment.printAssortment();

            application.Start();
            application.ShowMenu();
        }
    }
}