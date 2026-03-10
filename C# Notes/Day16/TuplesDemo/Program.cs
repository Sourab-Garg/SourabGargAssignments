namespace TuplesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, int Age, bool isActive) person = ("ravi", 30, true);
            Console.WriteLine($"Name:{person.Name}\n Age :{person.Age}\n" +
                $" Active:{person.isActive}");


            // so destructuring the tuple 

            var (name1, age1, isactive1) = person;

            Console.WriteLine($"Name:{name1}\n Age :{age1}\n" +
              $" Active:{isactive1}");
            Console.ReadLine();

        }
    }
}