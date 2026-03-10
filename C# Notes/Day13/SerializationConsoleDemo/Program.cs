using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace SerializationConsoleDemo
{
    [Serializable]
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name) 
        {
            Id = id;
            Name = name;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Employee emp1 = new Employee(101, "Ram");
            //string path = @"C:\dotnet\sample.json";
            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(fs, emp1);
            //fs.Close();
            //Console.WriteLine("File Created at: " + path);


            //string path = @"C:\dotnet\sample.json";
            //FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            //BinaryFormatter bf = new BinaryFormatter();
            //Employee emp2 = (Employee)bf.Deserialize(fs);
            //Console.WriteLine(emp2.Name);


            //string path1 = @"C:\dotnet\sample1.json";
            //string jsonString = JsonSerializer.Serialize(emp1);
            //File.WriteAllText(path1, jsonString);
            //Console.WriteLine("File Created at: " + path);

            string path1 = @"C:\dotnet\sample1.json";
            string jsonString = File.ReadAllText(path1);
            Employee emp3 = JsonSerializer.Deserialize<Employee>(jsonString);
            Console.WriteLine(emp3.Name);

            Console.ReadLine();
        }
    }
}
