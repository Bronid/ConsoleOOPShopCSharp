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

            application.Start();
            while (application.isStart)
            {
                application.ShowMenu();
                application.Select();
            }
        }
    }
}