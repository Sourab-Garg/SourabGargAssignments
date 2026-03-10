namespace InterfaceDemo
{
    public abstract class Customer
    {
        public string customerName { get; set; }
        public string customerId { get; set; }

        public abstract double CalculateDiscount(double amount);
        public virtual void DisplayCustomerDetails()
        {
            Console.WriteLine($" {customerId} and {customerName}");
        }
    }


    public interface IsServiceEligible
    {
        void RequestService();
        bool IsEligibleForFreeDelivery(double orderValue);
    }

    public class RegularCustomer : Customer, IsServiceEligible
    {
        public int lolalityPoints { get; set; }
        public double amount { get; set; }
        public override double CalculateDiscount(double amount)
        {
            double discountAmount = 0;

            if ( lolalityPoints > 100)
            {
                discountAmount = amount * 0.05;
            }
            else
            {
                discountAmount = amount * 0.02;
            }
                return discountAmount;
        }
        public override void DisplayCustomerDetails()
        {
            base.DisplayCustomerDetails();
        }
        public void RequestService()
        {
            Console.WriteLine($"Regular Customer: Requesting Standard Delivery Request.");
        }

        public bool IsEligibleForFreeDelivery(double orderValue)
        {
            bool freeDelivery = false;
               
            if ( orderValue > 500)
            {
                freeDelivery = true;
            }

            return freeDelivery;
        }
    }

    public class VIPCustomer : Customer, IsServiceEligible
    {
        public string MembershipTier { get; set; }
        public double AnnualSped { get; set; }
        public override double CalculateDiscount(double amount)
        {
            double discountAmount = 0;

            if(MembershipTier == "Gold")
            {
                discountAmount = amount * 0.15;
            }
            else
            {
                discountAmount= amount * 0.20;
            }

                return discountAmount;
        }
        public override void DisplayCustomerDetails()
        {
            base.DisplayCustomerDetails(); 
            Console.WriteLine($"Tier: {MembershipTier}");
        }

        public void RequestService()
        {
            Console.WriteLine($"VIP {MembershipTier} Customer: Requesting Priority Concierge Service.");
        }

        public bool IsEligibleForFreeDelivery(double orderValue)
        {
            bool freeDelivery = true;

            return freeDelivery; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Testing Regular Customer ---");
            RegularCustomer regCust = new RegularCustomer();
            regCust.customerName = "Raghu";
            regCust.customerId = "R-001";
            regCust.lolalityPoints = 400;

            double orderValue = 9;

            regCust.DisplayCustomerDetails();
            Console.WriteLine($"Discount amount: {regCust.CalculateDiscount(orderValue)} on order of {orderValue}.");
            regCust.RequestService();
            Console.WriteLine($"Is eligible for free delivery? {regCust.IsEligibleForFreeDelivery(orderValue)}");

            Console.WriteLine("\n---------------------------\n");

            Console.WriteLine("--- Testing VIP Customer ---");
            VIPCustomer vipCust = new VIPCustomer();
            vipCust.customerName = "Vikram";
            vipCust.customerId = "V-999";
            vipCust.MembershipTier = "Gold";

            double vipOrderValue = 450; 

            vipCust.DisplayCustomerDetails();
            Console.WriteLine($"Discount amount: {vipCust.CalculateDiscount(vipOrderValue)} on order of {vipOrderValue}");
            vipCust.RequestService();
            Console.WriteLine($"Is eligible for free delivery? {vipCust.IsEligibleForFreeDelivery(vipOrderValue)}");

            Console.ReadLine();
        }
    }
}