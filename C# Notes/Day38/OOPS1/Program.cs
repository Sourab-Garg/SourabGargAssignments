using System.Text.RegularExpressions;
using System.Transactions;

namespace OOPS1
{
    public interface IPaymentProcessor
    {
        decimal ProcessPayment(decimal amount);
    }

    public abstract class BaseGateway: IPaymentProcessor
    {
        protected decimal ServiceFee;
        public virtual decimal CalculateTax(decimal amount)
        {
            return (amount * 0.10m) + ServiceFee;
        }
        public abstract decimal ProcessPayment(decimal amount);
    }
    public class USAGateway : BaseGateway
    {
        public override decimal CalculateTax(decimal amount)
        {
            return (amount * 0.25m) + ServiceFee;
        }
        public override decimal ProcessPayment(decimal amount)
        {
            return CalculateTax(amount)+amount;
        }
    }
    public class TransactionRecord
    {
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public string MerchantCode { get; set; }

        //public TransactionRecord(decimal amount, string status, string merchantCode)
        //{
        //    Amount = amount;
        //    Status = status;
        //    MerchantCode = merchantCode;
        //}

    }
    public static class SecurityVault
    {
        public static string TransactionPattern = "^[A-Z]{3}-[0-9]{4}-[A-Z]{2}$";
        public static bool ValidateCode(string code)
        {
            return Regex.IsMatch(code, TransactionPattern);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //var transactions = new List<TransactionRecord>
            //{
            //    new TransactionRecord(150.00m,"Completed","TXN-1024-US")
            //};
            List<TransactionRecord> transactions = new List<TransactionRecord>
            {
                new TransactionRecord { Amount = 150.00m, Status = "Completed", MerchantCode = "TXN-1024-US" },
                new TransactionRecord { Amount = 50.00m,  Status = "Pending",   MerchantCode = "TXN-2020-UK" },
                new TransactionRecord { Amount = 300.75m, Status = "Completed", MerchantCode = "INVALID-99" },
                new TransactionRecord { Amount = 85.20m,  Status = "Completed", MerchantCode = "TXN-5566-FR" },
                new TransactionRecord { Amount = 10.00m,  Status = "Failed",    MerchantCode = "TXN-1234-DE" },
                new TransactionRecord { Amount = 420.00m, Status = "Completed", MerchantCode = "TXN-8888-CA" },
                new TransactionRecord { Amount = 99.99m,  Status = "Completed", MerchantCode = "txn-1024-us" }
            };
            IPaymentProcessor gateway = new USAGateway();

            foreach (var t in transactions)
            {
                if (t.Status == "Completed" && SecurityVault.ValidateCode(t.MerchantCode))
                {
                    decimal finalAmount = gateway.ProcessPayment(t.Amount);
                    Console.WriteLine($"Processed: {t.MerchantCode} → Final Amount: {finalAmount}");
                }
                else
                {
                    Console.WriteLine($"Skipped: {t.MerchantCode}");
                }
            }

            Console.ReadLine();
        }
    }
}
