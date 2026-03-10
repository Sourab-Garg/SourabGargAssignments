namespace Test6
{
    public static class Logger
    {
        public static void LogInfo(string msg)
        {
            Console.WriteLine($"Logging: {msg}");
        }
    }
    public abstract class Payment
    {
        public double amount { get; set;  }

        public abstract void Process();
        public virtual void ShowTransactionDetails()
        {
            Console.WriteLine($"Processing amount: {amount}");
        }

    }
    public class CreditCardPayment : Payment
    {   
        public CreditCardPayment(double amt)
        {
            amount = amt;
        }
        public override void Process()
        {
            Console.WriteLine($"Payment of {amount} processed via Credit Card.");
        }
    }

    public class UpiPayment : Payment
    {
        public UpiPayment(double amt)
        {
            amount = amt;
        }
        public override void Process()
        {
            Console.WriteLine($"Payment of {amount} processed via UPI ID");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Logger.LogInfo("Payment processing");

            CreditCardPayment cp = new CreditCardPayment(22.22);
            UpiPayment up = new UpiPayment(11.11);

            cp.Process();
            up.Process();
            cp.ShowTransactionDetails();

            Console.ReadLine();
        }
    }
}
