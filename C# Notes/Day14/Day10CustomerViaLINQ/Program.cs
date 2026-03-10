namespace Day10CustomerViaLINQ
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        static List<Customer> clist = new List<Customer>()
        {
            new Customer {CustomerID=101, CustomerName="ravi"},
            new Customer {CustomerID=102, CustomerName="Sita"},
            new Customer {CustomerID=103, CustomerName="sohan"},
        };

        public static List<Customer> Retrive()
        {
            return clist;
        }

        public static void PrintCustomers(List<Customer> clist)
        {
            Console.WriteLine("\nDisplaying customers:");
            foreach (Customer c in clist)
            {
                Console.WriteLine($"{c.CustomerID}---{c.CustomerName}");
            }
        }

        public static void InsertCustomer(Customer c, List<Customer> clist)
        {
            clist.Add(c);
        }

        public static Customer FindCustomer(int custId, List<Customer> clist)
        {
            return clist.FirstOrDefault(c => c.CustomerID == custId);
        }

        public static void UpdateCustomer(int custId, List<Customer> clist)
        {
            var customer = clist.FirstOrDefault(c => c.CustomerID == custId);
            if (customer != null)
            {
                Console.WriteLine("\nEnter new name:");
                string newName = Console.ReadLine();
                customer.CustomerName = newName;
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }

        public static void DeleteCustomer(int custId, List<Customer> clist)
        {
            var customer = clist.FirstOrDefault(c => c.CustomerID == custId);
            if (customer != null)
            {
                clist.Remove(customer);
                Console.WriteLine("Customer deleted successfully!");
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }
        }
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                List<int> numbers = new List<int> { 1, 29, 45 };
                Console.WriteLine("Numbers:");
                foreach (int num in numbers)
                {
                    Console.Write($"\t{num}");
                }
                Console.WriteLine();

                // Display names list
                List<string> names = new List<string> { "ravi", "sudha", "mohan" };
                Console.WriteLine("Names:");
                foreach (string name in names)
                {
                    Console.WriteLine(name);
                }

                // Remove duplicates using LINQ Distinct
                var array = new int[] { 1, 2, 3, 2, 3, 4, 5, 6, 4, 8, 9, 10, 5 };
                var uniqueNumbers = array.Distinct().ToList();
                Console.WriteLine("\nUnique numbers from array:");
                foreach (int ele in uniqueNumbers)
                {
                    Console.Write($"\t{ele}");
                }
                Console.WriteLine();

                // Customer CRUD operations using LINQ
                List<Customer> custList = Customer.Retrive();
                Console.WriteLine("\n=== Initial Customers ===");
                Customer.PrintCustomers(custList);

                // Insert new customer
                Customer newCustomer = new Customer { CustomerID = 104, CustomerName = "mahesh" };
                Customer.InsertCustomer(newCustomer, custList);
                Console.WriteLine("\n=== After Insert ===");
                Customer.PrintCustomers(custList);

                // Find customer
                Console.WriteLine("\nEnter ID to find customer name:");
                int custId = Convert.ToInt16(Console.ReadLine());
                Customer custFound = Customer.FindCustomer(custId, custList);
                if (custFound != null)
                {
                    Console.WriteLine($"Customer {custFound.CustomerID}: {custFound.CustomerName}");
                }
                else
                {
                    Console.WriteLine("Customer not found in list.");
                }

                // Update customer
                Console.WriteLine("\nEnter ID to update name:");
                int custId2 = Convert.ToInt16(Console.ReadLine());
                Customer.UpdateCustomer(custId2, custList);
                Console.WriteLine("\n=== After Update ===");
                Customer.PrintCustomers(custList);

                // Delete customer
                Console.WriteLine("\nEnter ID to delete customer:");
                int custId3 = Convert.ToInt32(Console.ReadLine());
                Customer.DeleteCustomer(custId3, custList);
                Console.WriteLine("\n=== After Delete ===");
                Customer.PrintCustomers(custList);

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadLine();

            }
        }
    }