namespace ParseConvertDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tryparsedemo();
            //parsedemo();

            Console.WriteLine("Enter Product Price ");
            decimal price = Convert.ToDecimal(string.IsNullOrWhiteSpace(Console.ReadLine()));

            Console.WriteLine($"Product Price is : {price}");
            Console.ReadLine();
        }

        private static void parsedemo()
        {
            Console.WriteLine("Enter Product Price ");
            decimal price = decimal.Parse(Console.ReadLine());
            //here if u enter wrong value exception will be thrown
            Console.WriteLine($"Product Price is : {price}");
        }

        private static void tryparsedemo()
        {

            Console.WriteLine("Enter Product Price ");
            string input = Console.ReadLine();
            bool isvalid = decimal.TryParse(input, out decimal price);
            // if it becomes true then it will store its value in price variable
            // try parse return type is boolean
            // for any type i can do tryparse ,here this will not throw exception 
            // becasue i am handing in else block the logic 
            if (isvalid)
            {
                Console.WriteLine($"Product Price is : {price}");
            }
            else
            {
                Console.WriteLine("Invalid Price Input please enter numeric value");
            }
        }
    }
}