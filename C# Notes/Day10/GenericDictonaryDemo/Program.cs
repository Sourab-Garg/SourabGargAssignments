namespace GenericDictonaryDemo
{
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            Console.WriteLine("Enter number of element in dictonary: ");
            int counter = Convert.ToInt16(Console.ReadLine());
            for(int i = 0; i < counter; i++)
            {
                Console.WriteLine("enter key");
                int key = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine($"Enter {key}'s value: ");
                string value = Console.ReadLine();
                dict.Add(key, value);
            }

            //foreach (int key in dict.Keys)
            //{
            //    Console.WriteLine($"Key: {key} and value: {dict[key]}.");
            //}

            foreach (KeyValuePair<int, string> pair in dict) {
                Console.WriteLine($"Key: {pair.Key} and value: {pair.Value}.");
            }

            Dictionary <double, Customer> dictCustomer = new Dictionary<double, Customer>()
            {
                {191.21, new Customer{Id = 12, Name="Sham" } }
            };

            Console.ReadLine();
        }
    }
}
