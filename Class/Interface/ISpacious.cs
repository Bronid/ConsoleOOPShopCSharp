using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.Interface
{
    public interface ISpacious<T>
    {
        public void Add(T obj);
        public void PrintListInfo();
    }
}
