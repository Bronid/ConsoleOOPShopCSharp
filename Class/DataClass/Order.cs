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
        private string userLogin = "";
        private string productName = "";
        private float productPrice = 0;
        private int count = 0;
        private string date = "";

        public Order(string userLogin, string productName, float productPrice, int count, string date)
        {
            this.userLogin = userLogin;
            this.productName = productName;
            this.productPrice = productPrice;
            this.count = count;
            this.date = date;
        }

        public new string ToString() => $"Product: {productName}, Price per one: {productPrice}, Count: {count}, Date: {date}\n";
        public float getProductPrice() => productPrice;
        public int getCount() => count;

    }
}
