﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class
{
    internal interface ISpacious<T>
    {
        public void Add(T a);
        public void Remove(int id);
        public void PrintListInfo();
    }
}
