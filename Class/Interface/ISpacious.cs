using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.Interface
{
    internal interface ISpacious<T>
    {
        public void Add(T obj);
        public void Remove(int id);
        public void PrintListInfo();
    }
}
