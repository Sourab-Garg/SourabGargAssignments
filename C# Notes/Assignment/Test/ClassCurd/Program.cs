using System.Collections.Generic;

namespace ClassCurd
{
    class Customer
    {
        public int id { get; set; }
        public string name { get; set; }

        public static List<Customer> Retrive()
        {
            List<Customer> cusList = new List<Customer>()
            { 
                new Customer() {id = 101, name = "Sham"},
                new Customer() {id = 102, name = "Ram"},
            };
            return cusList;
        }

        public static void PrintCustomer(List<Customer> list)
        {
            Console.WriteLine("Printing:");
            foreach (Customer c in list)
            {
                Console.WriteLine(c.id+ " "+ c.name);
            }
        }

        public static void InsertCustomer(Customer c, List<Customer> list)
        {
            list.Add(c);
        }

        public static Customer FindCustomer(int fid, List<Customer> list)
        {
            Customer foundedCus = null;
            foreach(Customer c in list)
            {
                if(c.id == fid)
                {
                    foundedCus = c; 
                    break; 
                }
            }

            return foundedCus;
        }

        public static void UpdateCustomer(int uid, string newName, List<Customer> list)
        {
            foreach (Customer c in list)
            {
                if (c.id == uid) 
                { 
                    c.name = newName;
                    return;
                }
            }
            Console.WriteLine("Customer not found, no updation");
        }

        public static void DeleteCustomer(int uid, List<Customer> list)
        {
            Customer temp = null;
            foreach(Customer c in list)
            {
                if( c.id == uid)
                {
                    temp = c;
                    break;
                }
            }
            if(temp != null)
            {
                list.Remove(temp);
                Console.WriteLine("Deleted successfully.");
            }
            else
            {   
                Console.WriteLine("Customer not found, no deletion");
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Customer> mainList = Customer.Retrive();

            Console.WriteLine(mainList.Count);

            Customer newCus = new Customer() {id = 109, name="Sye" };

            Customer.InsertCustomer(newCus, mainList);
            Customer.PrintCustomer(mainList);

            Console.WriteLine("Finding: ");
            Customer findRes = Customer.FindCustomer(109, mainList);
            if (findRes != null)
            {
                Console.WriteLine(findRes.id + " " + findRes.name);
            }
            else
            {
                Console.WriteLine("Customer not found!");
            }

            Console.WriteLine("Updating: ");
            Customer.UpdateCustomer(109, "Sourab", mainList);
            Customer.PrintCustomer(mainList);

            Customer.DeleteCustomer(109, mainList);
            Customer.PrintCustomer(mainList);

                Console.ReadLine();
        }
    }
}
