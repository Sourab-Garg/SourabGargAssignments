namespace ExceptionHandling
{
    public class PositiveValue : Exception
    {
        public PositiveValue() :base("Positive Value Error") { }
        public PositiveValue(string msg) : base(msg) { }

    }
    public class NoMoney : Exception
    {
        public NoMoney() : base("No money Error") { }
        public NoMoney(string msg) : base(msg) { }
    }

    public class Account
    {
        public double Balance { get; set; }

        public Account(int balance)
        {
            Balance = balance;
        }
        public void Deposit(double amt)
        {
            if (amt < 0)
            {
                throw new PositiveValue($"Deposit amount cant be {amt}");
            }
            else
            {
                Balance += amt;
            }
        }
        public void Withdraw(double amt)
        {
            if (amt > Balance)
            {
                throw new NoMoney($"Insuffiinet balance {amt}");
            }
            else
            {
                Balance -= amt;
            }
        }
    }
        internal class Program
        {
            static void Main(string[] args)
            {
                Account ac = new Account(100); 

            try
            {
                ac.Deposit(100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ac.Withdraw(100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ac.Deposit(-100);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                ac.Withdraw(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Final Balance: {ac.Balance}");

            Console.ReadLine();
            }
        }
    }