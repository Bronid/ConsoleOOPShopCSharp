using ConsoleOOPShopCSharp.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class Order
    {
        private int Id;
        private string Date;
        private List<Product> Products;
        private new string ToString() => $"Id: {Id}  Date: {Date}\n";
        public void PrintListInfo()
        {
            float sum = 0;
            ToString();
            Console.WriteLine($"Products: ");
            for (int i = 0; i < Products.Count; i++)
            {
                Console.Write(i + 1 + ". ");
                Products[i].ToString();
                sum += Products[i].GetProductPrice();
            }
            Console.WriteLine($"Summary: {sum}");
        }
    }
}
