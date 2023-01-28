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
    public class CategoryEnum : IEnumerator
    {
        private List<Category> categories;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public CategoryEnum(List<Category> categories)
        {
            this.categories = categories;
        }

        public bool MoveNext()
        {
            position++;
            return (position < categories.Count);
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

        public Category Current
        {
            get
            {
                try
                {
                    return categories[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
