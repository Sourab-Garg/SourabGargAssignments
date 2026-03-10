namespace EnumsDemo
{
    internal class Program
    {
        enum weekdays {  sun=10, mon, tue=15, wed, thu, fri, sat};
        static void Main(string[] args)
        {
            Console.WriteLine(Convert.ToInt32(weekdays.fri));

            Console.ReadLine();
        }
    }
}
