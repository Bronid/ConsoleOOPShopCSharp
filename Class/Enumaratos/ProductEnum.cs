using ConsoleOOPShopCSharp.Class.DataClass;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOOPShopCSharp.Class.Enumaratos
{
    // When you implement IEnumerable, you must also implement IEnumerator.
    public class ProductEnum : IEnumerator
    {
        private List<Product> products;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public ProductEnum(List<Product> products)
        {
            this.products = products;
        }

        public bool MoveNext()
        {
            position++;
            return (position < products.Count);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public Product Current
        {
            get
            {
                try
                {
                    return products[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
