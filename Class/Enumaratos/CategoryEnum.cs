using ConsoleOOPShopCSharp.Class.DataClass;
using System.Collections;

namespace ConsoleOOPShopCSharp.Class.Enumaratos
{
    public class CategoryEnum : IEnumerator
    {
        private List<Category> categories;

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
