namespace BoxingUnboxing
{
    internal class Program
    {
        class Emp
        {
           public int aa;
        }
        static void Main(string[] args)
        {
            object obj1, obj2; // reference types
            string str1;
            Emp emp = new Emp();

            int a; // value type
            a = 5;

            obj1 = a; //boxing
            Console.WriteLine($"Object one: {obj1}"); //Unboxing
            
            obj2 = 9; //boxing
            str1 = a.ToString(); // boxing
            Console.WriteLine($"String 1: {str1}"); //Unboxing
            emp.aa = 12; //boxing
            Console.WriteLine($"The employee value is: {emp.aa}");

            int? salary; //nullable types, can store null
            string? name;

            salary = null;
            name = null;

            Console.WriteLine();
        }
    }
}
