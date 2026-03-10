using System.Reflection.Metadata.Ecma335;

namespace Q3
{
    public interface IDiscountStrategy
    {
        double ApplyDiscount(double total);
    }
    public class NoDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double total)
        {
            return total;
        }
    }
    public class SeasonalDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double total)
        {
            return total - (total * 0.10);
        }
    }
    public class PremiumCustomerDiscount: IDiscountStrategy
    {
        public double ApplyDiscount(double total)
        {
            return total - (total * 0.20);
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
    public class Order : Item
    {
        IDiscountStrategy Strategy;
        public Order(IDiscountStrategy _strategy)
        {
            Strategy = _strategy;
        }
        List<Item> items = new List<Item>();
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public double CalculateSubtotal()
        {
            return items.Sum(x=>x.Price*x.Quantity);
        }
        public double ApplyTax()
        {
            return CalculateSubtotal() * 0.05;
        }
        public double ApplyDiscountStrategy()
        {
            double subTotal = CalculateSubtotal();
            double taxed = ApplyTax() + subTotal;
            return Strategy.ApplyDiscount(taxed);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            IDiscountStrategy strategy;
            switch (input)
            {
                case ("Premium"):
                    strategy = new PremiumCustomerDiscount();
                    break;
                case ("Seasonal"):
                    strategy = new SeasonalDiscount();
                    break;
                default:
                    strategy = new NoDiscount();
                    break;
            }

            Order order = new Order(strategy);

            order.AddItem(new Item { Name = "Shirt", Price = 2000, Quantity = 2 });
            order.AddItem(new Item { Name = "Shoes", Price = 3000, Quantity = 1 });

            Console.WriteLine(order.CalculateSubtotal()+order.ApplyTax());
            Console.WriteLine(order.ApplyDiscountStrategy());
        }
    }
}
