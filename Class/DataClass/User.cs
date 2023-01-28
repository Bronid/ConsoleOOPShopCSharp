﻿using ConsoleOOPShopCSharp.Class.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class User
    {
        private List<Order> orders = new();

        private string Name = "";
        private string Password = "";
        private float Balance = 0;
        private string Group = "";
        

        public User(string name, string password, float balance, string group)
        {
            Name = name;
            Password = password;
            Balance = balance;
            Group = group;
        }

        public string GetLogin() { return Name; }
        public float GetBalance() { return Balance; }
        public List<Order> GetOrders() { return orders; }
        public void PrintListInfo()
        {
            float sum = 0;
            Console.WriteLine($"{Name} order history list:");
            for (int i = 0; i < orders.Count; i++)
            {
                Console.Write(i + 1 + $". {orders[i].ToString()}");
                sum += orders[i].getProductPrice() * orders[i].getCount();
            }
            Console.WriteLine($"Summary: {sum}");
        }
    }
}