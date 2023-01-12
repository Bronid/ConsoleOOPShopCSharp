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

        public int NumTesterCategories(int size)
        {
            int index = 0;
            do
            {
                try
                {
                    index = int.Parse(Console.ReadLine());
                    if (index < 0 || index > size)
                    {
                        Console.WriteLine($"There are only {size} categories");
                        break;
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

