namespace CustomExceptopnTest1
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message):base(message) { }
        public InsufficientBalanceException() : base("Insufficient Balance") { }
    }
    public class BankAccount
    {
        public double Balance { get; private set; }

        public BankAccount(double balance)
        {
            Balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (amount > Balance)
            {
                //throw new InsufficientBalanceException($"Withdrawal of {amount} failed. Available balance: {Balance}");
                throw new InsufficientBalanceException();
            }

            Balance -= amount;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount(5000);
                account.Withdraw(6000);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Custom Exception Caught:");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
