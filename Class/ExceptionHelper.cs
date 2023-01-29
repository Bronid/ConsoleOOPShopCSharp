using ConsoleOOPShopCSharp.Class.DataClass;
using System;
namespace ConsoleOOPShopCSharp.Class
{
	public class ExceptionHelper
	{
		public ExceptionHelper()
		{

		}

        public int NumTester()
        {
            int index = 0;
            do
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please write a NUMBER");
                    index = -1;

                }
            } while (index == -1);
            return index;
        }

        public int NumTesterPrice()
        {
            int index = 0;
            do
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                    if(index < 0)
                    {
                        Console.WriteLine("The price of a product cannot be negative!");
                        index = -1;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please write a NUMBER");
                    index = -1;

                }
            } while (index == -1);
            return index;
        }

        public int NumTesterCategories(Assortment p)
        {
            int index = 0;
            do
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                    if (index == 0) return index;

                    if (index <= 0 || index > p.categories.Count)
                    {
                        Console.WriteLine($"There are only {p.categories.Count} categories");
                        index = -1;
                    }
                }
                catch 
                {
                    Console.WriteLine("Please write a NUMBER");
                    index = -1;

                }
            } while (index == -1);

            return index;
        }

        public int NumTesterProducts(Assortment p, int indexCategory)
        {
            int index = 0;
            do
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                    if (index <= 0 || index > p.categories[indexCategory].GetListCount())
                    {
                        Console.WriteLine($"There are only {p.categories[indexCategory].GetListCount()} product/s");
                        index = -1;
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please write a NUMBER");
                    index = -1;

                }
            } while (index == -1);

            return index;
        }
    }
}

