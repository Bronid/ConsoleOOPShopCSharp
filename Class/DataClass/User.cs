using ConsoleOOPShopCSharp.Class.Interface;

namespace ConsoleOOPShopCSharp.Class.DataClass
{
    public class User : ISpacious<Order>
    {
        private List<Order> orders = new();

        private string Name = "";
        private float Balance = 0;
        
        public User(string name, float balance)
        {
            Name = name;
            Balance = balance;
        }
        public void Add(Order obj) => orders.Add(obj);
        public string GetLogin() { return Name; }
        public float GetBalance() { return Balance; }
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
