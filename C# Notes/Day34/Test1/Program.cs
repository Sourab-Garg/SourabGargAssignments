namespace Test1
{
    public abstract class BankAccount
    {
        public int AccountNumber { get; set; }
        public string HolderName { get; set; }
        public double Balance {  get; set; }

        public BankAccount(int accountNumber, string holderName, double balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }
        public abstract double CalculateInterest();
        public virtual string GetAccountType()
        {
            return "General";
        }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {
            Balance -= amount;
        }
    }

    public class SavingAccount : BankAccount
    {
        public double InterestRate = 0.05;
        public SavingAccount(int AccountNumber, string HolderName, double Balance ) : base(AccountNumber, HolderName, Balance) { }
        public override double CalculateInterest()
        {
            return Balance * InterestRate;
        }
        public override string GetAccountType()
        {
            return "Saving";
        }
    }
    public class CurrentAccount : BankAccount
    {
        public double InsterestRate = 0.02;

        public CurrentAccount(int AccountNumber, string HolderName, double Balance) : base(AccountNumber, HolderName, Balance) { }
        public override double CalculateInterest()
        {
            return Balance * InsterestRate;
        }
        public override string GetAccountType()
        {
            return "Current";
        }
    }

    internal class Program
    {
        public static double GetTotalBankBalance(List<BankAccount> accounts)
        {
            return accounts.Sum(x => x.Balance);
        }

        public static void PrintHighValueAccounts(List<BankAccount> accounts)
        {
            double avg = accounts.Average(a => a.Balance);
            var highestN = accounts
            .Where(x => x.Balance > avg)
            .Select(x => new
            {
                Name = x.HolderName,
                Cash = x.Balance
            });
            foreach (var acc in highestN)
            {
                Console.WriteLine($"{acc.Name}: {acc.Cash}");
            }
        }

        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>
            {
                new SavingAccount(1, "Ram", 80000),
                new CurrentAccount(2, "Aman", 40000),
                new SavingAccount(3, "Shyam", 60000),
                new CurrentAccount(4, "Mohan", 30000)
            };

            Console.WriteLine(GetTotalBankBalance(accounts));

            PrintHighValueAccounts(accounts);

            var summary = accounts
            .GroupBy(a => a.GetAccountType())
            .Select(g => new {
                Type = g.Key,
                Total = g.Sum(a => a.Balance)
            });

            foreach (var item in summary)
            {
                Console.WriteLine($"{item.Type} Total: {item.Total}");
            }

            Console.ReadLine();
        }
    }
}
