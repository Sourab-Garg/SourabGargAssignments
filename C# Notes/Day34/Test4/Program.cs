namespace Test4
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public static int PersonCount = 0;

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
            PersonCount++;
        }
        public abstract string GetRole();
        public virtual string GetDetails()
        {
            return "Default Details";
        }

    }
    public class Student : Person
    {
        public string Department { get; set; }
        public List<int> Marks { get; set; }

        public Student(int Id, string Name, int Age, string department, List<int> marks):base(Id, Name, Age)
        {
            Department = department;
            Marks = marks;
        }
        public override string GetRole()
        {
            return "Student";
        }
        public double CalculateAverageMarks()
        {
            return Marks.Average(x => x);
        }
    }
    public class Professor : Person
    {
        public string Department { get; set; }
        public double Salary { get; set; }

        public Professor(int Id, string Name, int Age, string department, double salary) : base(Id, Name, Age)
        {
            Department = department;
            Salary = salary;
        }
        public override string GetRole()
        {
            return "Professor";
        }
    }
    public static class UniversityAnalytics
    {
        public static double GetTotalSalary(List<Person> persons)
        {
            return persons.OfType<Professor>().Sum(x => x.Salary);
        }
        public static double GetOverallAverageMarks(List<Person> persons)
        {
            double avg = persons.OfType<Student>().Average(x => x.CalculateAverageMarks());
            return Math.Round(avg, 2);
        }
        public static List<Student> GetTopStudents(List<Person> persons)
        {
            return persons.OfType<Student>().Where(x=> x.CalculateAverageMarks() > 90).ToList();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Student(1, "Ram", 20, "CSE", [80,85,90]),
                new Student(2, "Aman", 22, "ECE", [70,75,80]),
                new Professor(3, "Dr. Rao", 45, "CSE", 90000),
                new Student(4, "Shyam", 21, "CSE", [88,92,95]),
                new Professor(5, "Dr. Mehta", 50, "ECE", 85000)
            };

            Console.WriteLine(UniversityAnalytics.GetOverallAverageMarks(persons));
            var topStudents = UniversityAnalytics.GetTopStudents(persons);
            foreach (var student in topStudents)
            {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine(UniversityAnalytics.GetTotalSalary(persons));
            var avgmarks = persons.OfType<Student>()
                          .Select(s => new
                          {
                              s.Name,
                              Average = s.CalculateAverageMarks()
                          });
            foreach (var item in avgmarks)
            {
                Console.WriteLine($"{item.Name} - {item.Average:F2}");
            }


            Console.ReadLine();
        }
    }
}
