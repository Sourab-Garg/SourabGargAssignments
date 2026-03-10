namespace Record_Demo { 
public record Person(string Name, int Age);
internal class Program
{
    static void Main(string[] args)
    {
        Person p1 = new Person("John", 20);
        Person p2 = new Person("Scott", 34);
        Console.WriteLine($"{p1.Name}--{p1.Age}");
        Console.WriteLine($"{p2.Name}--{p2.Age}");
        //            p1.Name="David"//error
        // only in constructor u can set the values 

        Console.ReadLine();
    }
}
}