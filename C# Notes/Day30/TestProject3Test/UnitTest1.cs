namespace TestProject3Test
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit amount should be positive");
            }
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds");
            Balance -= amount;
        }
    }

    [TestFixture]
    public class TestCases
    {
        [Test]
        public void Deposit1()
        {
            var account = new BankAccount();
            account.Deposit(100);
            Assert.AreEqual(100, account.Balance);
        }
        [Test]
        public void Deposit2()
        {
            var account = new BankAccount();
            account.Withdraw(10);
            Assert.AreEqual(10, account.Balance);
        }
        [Test]
        public void Deposit3()
        {
            var account = new BankAccount();
            account.Deposit(100);
            account.Withdraw(100);
            Assert.AreEqual(0, account.Balance);
        }
        [Test]
        public void Deposit4()
        {
            var account = new BankAccount();
            Assert.AreEqual(0, account.Balance);
        }
    }
}