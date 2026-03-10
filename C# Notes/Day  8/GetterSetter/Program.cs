namespace GetterSetter
{
    class Customer
    {
        private int _cid = -1;
        public int ID
        {
            set
            {
                _cid = value;
            }
            get
            {
                return _cid;
            }
        }
        private string _Cname = string.Empty;
        public string CustomerName
        {
            set
            {
                _Cname = value;
            }
            get
            {
                return _Cname;
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Customer obj = new Customer();
            obj.ID = 101;
            obj.CustomerName = "ravi";
            Console.WriteLine($"{obj.ID}--{obj.CustomerName}");
            Console.ReadLine();
        }
    }
}
