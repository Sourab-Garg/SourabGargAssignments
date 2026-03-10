namespace GenericListDemo
{
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        public static List<Customer> Retrive()
        {
            List<Customer> cList = new List<Customer>()
            {
                new Customer() { CustomerID = 101, CustomerName = "Ravi" },

                new Customer() { CustomerID = 102, CustomerName = "Savi" },

                new Customer() { CustomerID = 103, CustomerName = "Cavi" }
            };
            return cList;
        }

        public static void PrintCustomers(List<Customer> cList)
        {
            Console.WriteLine("Displating Customers");
            foreach (Customer c in cList)
            {
                Console.WriteLine($"ID: {c.CustomerID} and Name: {c.CustomerName}.");
            }
        }

        public static void InsertCustomer(Customer c, List<Customer> clist)
        {
            clist.Add(c);
        }

        public static Customer findCustomer(int cusId, List<Customer> cList)
        {
            Customer customerFound = null;

            foreach (Customer c in cList)
            {
                if (c.CustomerID == cusId)
                {
                    {
                        customerFound = c; break;
                    }
                }
            }

            return customerFound;
        }
        public static void updateCustomer(int custId, List<Customer> cList)
        {
            for (int i = 0; i < cList.Count; i++) { 
                if(cList[i].CustomerID == custId)
                {
                    Console.WriteLine("Enter new name: ");
                    string newName = Console.ReadLine();
                    cList[i].CustomerName = newName;
                }
            }
        }

        public static void deleteCustomer(int custId, List<Customer> clist) { 
            for(int i = 0; i < clist.Count(); i++)
            {
                if (clist[i].CustomerID == custId)
                {
                    clist.RemoveAt(i);
                }
            }
            
        }

    }
        internal class Program
        {
            static void Main(string[] args)
                {
                List<int> numbers = new List<int>(){
                21,
                23,
                12
            };
                numbers.Add(1);
                numbers.Add(29);
                numbers.Add(45);

                List<string> names = new List<string>()
            {
            "ravi",
            "sudha",
            "mohan"

            };
                names.Add("sham");

                foreach (int num in numbers)
                {
                    Console.WriteLine(num);
                }

                foreach (string el in names)
                {
                    Console.WriteLine(el);
                }

                var array = new int[] { 1, 2, 3, 3, 2, 1 };
                var result = new List<int>();
                foreach (int num in array)
                {
                    bool found = false;
                    foreach (int el in result)
                    {
                        if (el == num)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found) result.Add(num);
                }

                foreach (int num in result)
                {
                    Console.WriteLine(num);
                }
                List<Customer> cusList = Customer.Retrive();
                Customer.PrintCustomers(cusList);
                Customer newCustomer = new Customer()
                {
                    CustomerID = 104,
                    CustomerName = "Gavi",
                };
                Customer.InsertCustomer(newCustomer, cusList);
                Customer.PrintCustomers(cusList);

                List<Customer> cusList1 = Customer.Retrive();
                Customer.PrintCustomers(cusList1);

                Console.WriteLine("Enter ID: ");
                int cusId = Convert.ToInt32(Console.ReadLine());
                Customer custFound = Customer.findCustomer(cusId, cusList);
                    if(custFound != null)
                {
                    Console.WriteLine(custFound.CustomerName +" "+ custFound.CustomerID);
                }
                else
                {
                    Console.WriteLine("Customer not found");
                }

                Console.WriteLine("Enter the id of customer to update name: ");
                int custId2 = Convert.ToInt32(Console.ReadLine());
                Customer.updateCustomer(custId2, cusList);
                Customer.PrintCustomers(cusList);

                Console.WriteLine("Enter customer id to delete: ");
                int custid = Convert.ToInt32(Console.ReadLine());

                Customer.deleteCustomer(custid, cusList);

                Customer.PrintCustomers(cusList);
                

                Console.ReadLine();
            }
        }
    }