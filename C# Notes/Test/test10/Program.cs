using System.Xml.Linq;

namespace test10
{
    public abstract class Payment
    {
        public double Amount { get; set; }
        public string TrsId { get; set; }
        public virtual string Mode { get; protected set; }
        public Payment(double amount, string trsId) {
            Amount = amount;
            TrsId = trsId;
        }

        public abstract void ProcessPayment();
    }

    public class CreditCard : Payment
    {
        public string Name { get; set; }
        public CreditCard(double amount, string trsId):base(amount, trsId)
        {
            Mode = "CreditCard";
            Name = "SBI";

        }
        public override void ProcessPayment()
        {
            Console.WriteLine($"{Mode} Payment of {Amount} with id {TrsId} from {Name}");
        }
    }
    public class Upi : Payment
    {
        public string App {  get; set; }

        public Upi(double amount, string trsId):base(amount, trsId) 
        {
            Mode = "UPI";
            App = "GPay"; 
        }

        public override void ProcessPayment()
        {
            Console.WriteLine($"{Mode} Payment of {Amount} with id {TrsId} from {App}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard sbicard =  new CreditCard(100, "34fs");
            sbicard.ProcessPayment();

            Upi gpay = new Upi(100, "233");
            gpay.ProcessPayment();

            Payment p1 = new CreditCard(100, "34fs");
            Payment p2 = new Upi(100, "233");

            p1.ProcessPayment();
            p2.ProcessPayment();

            Console.ReadLine();
        }
    }
}
