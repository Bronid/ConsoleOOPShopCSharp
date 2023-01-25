using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public List<Product> Products { get; set; }
    }
}
