namespace Solution2
{
    interface IServiceEligible
    {
        void RequestService();
        bool IsEligibleForFreeDelivery(double orderValue);
    }
    abstract class Customer
    {
        public string CustomerName { get; set; }
        public string CustomerID { get; set; }

        // Abstract method
        public abstract double CalculateDiscount(double amount);

        // Virtual method
        public virtual void DisplayCustomerDetails()
        {
            Console.WriteLine($"Customer ID   : {CustomerID}");
            Console.WriteLine($"Customer Name : {CustomerName}");
        }
    }
    class RegularCustomer : Customer, IServiceEligible
    {
        public int LoyaltyPoints { get; set; }

        public override double CalculateDiscount(double amount)
        {
            if (LoyaltyPoints > 100)
            {
                return amount * 0.05;
            }
            else
            {
                return amount * 0.02;
            }
        }

        public void RequestService()
        {
            Console.WriteLine("Service: Standard customer support provided.");
        }

        public bool IsEligibleForFreeDelivery(double orderValue)
        {
            return orderValue > 500;
        }

        public override void DisplayCustomerDetails()
        {
            base.DisplayCustomerDetails();
            Console.WriteLine($"Customer Type : Regular");
            Console.WriteLine($"Loyalty Points: {LoyaltyPoints}");
        }
    }
    class VIPCustomer : Customer, IServiceEligible
    {
        public string MembershipTier { get; set; }   
        public double AnnualSpend { get; set; }

        public override double CalculateDiscount(double amount)
        {
            if (MembershipTier == "Gold")
                return amount * 0.15;
            else if (MembershipTier == "Platinum")
                return amount * 0.20;
            else
                return 0;
        }

        public void RequestService()
        {
            Console.WriteLine($"Service: Priority service for {MembershipTier} member.");
        }

        public bool IsEligibleForFreeDelivery(double orderValue)
        {
            return true; // Always free for VIP
        }

        public override void DisplayCustomerDetails()
        {
            base.DisplayCustomerDetails();
            Console.WriteLine($"Customer Type : VIP");
            Console.WriteLine($"Tier          : {MembershipTier}");
            Console.WriteLine($"Annual Spend  : {AnnualSpend}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RegularCustomer r1 = new RegularCustomer
            {
                CustomerID = "R001",
                CustomerName = "ABC",
                LoyaltyPoints = 110
            };

            RegularCustomer r2 = new RegularCustomer
            {
                CustomerID = "R002",
                CustomerName = "DEF",
                LoyaltyPoints = 43
            };

            RegularCustomer r3 = new RegularCustomer
            {
                CustomerID = "R003",
                CustomerName = "GHI",
                LoyaltyPoints = 422
            };
            VIPCustomer v1 = new VIPCustomer
            {
                CustomerID = "V001",
                CustomerName = "JKL",
                MembershipTier = "Gold",
                AnnualSpend = 200000
            };
            VIPCustomer v2 = new VIPCustomer
            {
                CustomerID = "V002",
                CustomerName = "MNO",
                MembershipTier = "Platinum",
                AnnualSpend = 550000
            };
            double orderAmount = 1000;

            Customer[] customers = { r1, r2, r3, v1, v2 };

            Console.WriteLine("CUSTOMER DETAILS ARE AS FOLLOWING \n");

            foreach (Customer cust in customers)
            {
                cust.DisplayCustomerDetails();

                double discount = cust.CalculateDiscount(orderAmount);
                Console.WriteLine($"Order Amount : {orderAmount}");
                Console.WriteLine($"Discount     : {discount}");

                IServiceEligible service = (IServiceEligible)cust;
                service.RequestService();

                bool freeDelivery = service.IsEligibleForFreeDelivery(orderAmount);
                Console.WriteLine($"Free Delivery: {freeDelivery}");

                Console.WriteLine("----------------------------------\n");
            }

            Console.ReadLine();
        }
    }
}
    