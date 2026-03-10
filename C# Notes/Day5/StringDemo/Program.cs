using System.Text;

namespace StringDemo
{
    internal class Program
    {
        public static void concat1(string s1)
        {
            string st = "world";
            s1 = s1 + st;
        }

        public static void concat2(StringBuilder sb)
        {
            sb.Append(" Everyone");
        }
        static void Main(string[] args)
        {
            string x = "sourabgarg";
            string z = "sourabgarg";
            string y = x.Substring(0, 6);
            Console.WriteLine(y);   

            x = x.Substring(0,6);
            Console.WriteLine(x);
            z = z.Substring(6);
            Console.WriteLine(z);

            //second thing about string is it is referecne type 
            string fname;
            string mname;
            string lname;
            Console.WriteLine("Enter first name :");
            fname = Console.ReadLine();
            Console.WriteLine("Enter middle name :");
            mname = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            lname = Console.ReadLine();

            string fullName = fname + " " + mname+ " " + lname;
            Console.WriteLine(fullName);
            string fullName2 = string.Concat(fname, " ", mname, " ", lname);
            Console.WriteLine(fullName2);

            //as string is immutable i will go stringbuilder..in strings
            //whenver i create a string literal or concat i am creating a new obj
            //not good practise declare once and apped in that object which is
            //possible stringbuild and it is mutable also it can be changed 
            string s1 = "hello";
            StringBuilder sb1 = new StringBuilder("hai");
            concat1(s1);
            concat2(sb1);
            Console.WriteLine($"{s1}---{sb1}");
            string[] weekdays = new string[]
            { "Monday", "Tuesday", "Wednesday", "Thursday",
                "Friday", "Saturday", "Sunday" };

            // i want the output like this 
            // Monday ,Tuesday ,Wednesday ,Thursday,Friday ,
            // Saturday and Sunday but it will not happen as it is immutable 

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < weekdays.Length; i++)
            {
                sb.Append(weekdays[i]);
                if (i < weekdays.Length - 2)
                {
                    sb.Append(",");
                }
                else if (i == weekdays.Length - 2)
                {
                    sb.Append(", and ");
                }
            }

            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }
    }
}