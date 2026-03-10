namespace NamedOptionalParameterDemo
{
    internal class Program
    {
        public static void ShowMessage(int age=19, string name = "Raj")
        {
            Console.WriteLine($"Name is {name}, Age is {age}");
        }
        static void Main(string[] args)
        {
            ShowMessage(18, "Raj");
            ShowMessage(18);
            ShowMessage(name: "Raj");
            ShowMessage();
            Console.ReadLine();
        }
    }
}
