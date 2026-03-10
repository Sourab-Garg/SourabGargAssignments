namespace InterfaceDemo1
{
    public interface IPayment
    {
        string Mode { get; set; }
        double Amount { get; set; }
        void Pay();
    }

    public interface IPaymentManager
    {
        List<IPayment> GetPayments();
        void AddPayment(IPayment payment);
        void RemovePayment(IPayment payment);
        void UpdatePayment(int index, double newAmount);
        List<IPayment> GetTop(int top);
    }
    public class CreditCard : IPayment
    {
        public string Mode { get; set; }
        public double Amount {  set; get; }
        public CreditCard(string mode, double amount)
        {
            Mode = mode;
            Amount = amount;
        }
        public void Pay()
        {
            Console.WriteLine($"Credit Card payment of {Amount} from {Mode}");
        }
    }
    public class Upi : IPayment
    { 
        public string Mode { get; set; }
        public double Amount { set; get; } 
        public Upi(string mode, double amount)
        {
            Mode = mode;
            Amount = amount;
        }
        public void Pay()
        {
            Console.WriteLine($"UPI payment of {Amount} from {Mode}");
        }
    }
    public class PaymentManager : IPaymentManager
    {
        List<IPayment> _payments = new List<IPayment>();
        public List<IPayment> GetPayments()
        {
            return _payments;
        }
        public void AddPayment(IPayment payment)
        {
            _payments.Add(payment);
        }
        public void RemovePayment(IPayment payment)
        {
            _payments.Remove(payment);
        }
        public void UpdatePayment(int index, double newAmount)
        {
            if(index >= 0 && index < _payments.Count)
            {
                _payments[index].Amount = newAmount;
            }
        }

        public List<IPayment> GetTop(int top)
        {
            return _payments.OrderByDescending(x => x.Amount).Take(top).ToList();
           
        }

    }
  
    internal class Program
    {
        static void Main(string[] args)
        {
            IPayment p1 = new CreditCard("SBI", 100);
            IPayment p2 = new Upi("GPay", 10);
            IPayment p3 = new CreditCard("Axis", 1000);
            IPayment p4 = new CreditCard("HDFC", 10000);
            IPayment p5 = new Upi("GPay", 100000);

            p1.Pay();
            p2.Pay();
            p3.Pay();
            p4.Pay();
            p5.Pay();

            Console.WriteLine();

            IPaymentManager m1 = new PaymentManager();
            List<IPayment> payments = m1.GetPayments();
            m1.AddPayment(p1);
            m1.AddPayment(p2);
            m1.AddPayment(p3);
            m1.AddPayment(p4);
            m1.AddPayment(p5);
            m1.UpdatePayment(2, 100);
            List<IPayment> topPayments = m1.GetTop(3);
            foreach(IPayment payment in payments)
            {
                payment.Pay();
            }

            Console.WriteLine();
            foreach(IPayment payment in topPayments)
            {
                payment.Pay();
            }

            Console.ReadLine();
        }
    }
}
