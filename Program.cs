using ConsoleOOPShopCSharp.Class;

//test
namespace ConsoleOOPShopCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application application = new Application();
            Product a = new Product("Test", 12.4f);
            a.Print();
            Console.WriteLine("Hello, World!");
        }
    }
}