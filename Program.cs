﻿using ConsoleOOPShopCSharp.Class;
using System.Data.SQLite;

//test
namespace ConsoleOOPShopCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
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