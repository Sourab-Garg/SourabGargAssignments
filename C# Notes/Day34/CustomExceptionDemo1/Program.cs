namespace CustomExceptionDemo1
{
    public class InsufficientBalance : Exception
    {
        public InsufficientBalance() : base("Insufficinet Balance") { }
        public InsufficientBalance(string message) : base(message) { }
    }
    public class Account
    {
        public double Balance { get; private set; }

        public Account(double balance)
        {
            Balance = balance;
        }

        public void Withdraw(double amount)
        {
            if (Balance < amount)
            {
                //throw new InsufficientBalance();
                throw new InsufficientBalance($"Cant withdraw {amount} as balance is {Balance}");
            }
            Balance -= amount;
            Console.WriteLine($"{amount} Withdrawn!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(1000);
            try
            {
                acc.Withdraw(100);
                acc.Withdraw(1000);
            }
            catch (InsufficientBalance ex)
            {
                Console.WriteLine("Custom Exception");
                Console.WriteLine(ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("General Exception");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Thank you!");
            }
            Console.ReadLine();
        }
    }
}
