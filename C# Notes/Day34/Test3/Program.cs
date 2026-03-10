namespace Test3
{
    public abstract class Product
    {
        public static int ProductCount = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public Product(int id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
            ProductCount++;
        }
        public abstract double GetDiscountedPrice();
        public virtual string GetCategory()
        {
            return "Default";
        }
    }
    public class Electronics : Product
    {
        private const double DiscountRate = 0.10;
        public Electronics(int id, string name, double price)
            : base(id, name, price) { }
        public override string GetCategory()
        {
            return "Electronics";
        }
        public override double GetDiscountedPrice()
        {
            return base.Price - (base.Price * 0.20);
        }
    }
    public class Clothing : Product
    {
        private const double DiscountRate = 0.20;

        public Clothing(int id, string name, double price)
            : base(id, name, price) { }

        public override double GetDiscountedPrice()
        {
            return Price - (Price * DiscountRate);
        }

        public override string GetCategory()
        {
            return "Clothing";
        }
    }
    public static class ProductAnalytics
    {
        public static double GetTotalRevenue(List<Product> products)
        {
            return products.Sum(p => p.Price);
        }

        public static Product GetMostExpensiveProduct(List<Product> products)
        {
            return products.OrderByDescending(p => p.Price).First();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> 
            {
                new Electronics(1, "Laptop", 80000),
                new Clothing(2, "Jacket", 5000),
                new Electronics(3, "Mobile", 60000),
                new Clothing(4, "Shoes", 4000)
            };

            var discountedList = products.Select(x => new 
                                                            {
                                                                x.Name,
                                                                originalPrice = x.Price,
                                                                discountedPrice = x.GetDiscountedPrice()
                                                            });
            foreach (var item in discountedList)
                Console.WriteLine($"{item.Name} - ₹{item.originalPrice} - ₹{item.discountedPrice}");

            var countPerCategory = products.GroupBy(x => x.GetCategory())
                                           .Select(s => new 
                                                        {
                                                            category = s.Key,
                                                            count = s.Count()
                                                        });

            foreach (var item in countPerCategory)
                Console.WriteLine($"{item.category} - {item.count}");

            Console.ReadLine();
        }
    }
}
