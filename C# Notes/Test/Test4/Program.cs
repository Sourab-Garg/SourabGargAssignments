using System;
using System.Collections.Generic;
using System.Linq;

namespace Test4
{
    public class StudentMarks
    {
        public string Name { get; set; } = string.Empty;  
        public double Math { get; set; }
        public double Science { get; set; }
        public double English { get; set; }

        public override string ToString()
        {
            return $"{Name}: M{Math:F1} S{Science:F1} E{English:F1}";
        }
    }
    public static class MarksAnalyzer
    {
        public static Dictionary<string, List<double>> GroupBySubject(List<StudentMarks> students)
        {
            return new Dictionary<string, List<double>>() {
                {"Math",  students.Select(x=> x.Math).ToList()},
                {"Science", students.Select(x => x.Science).ToList()},
                {"English", students.Select(x=> x.English).ToList()}
            };
        }

        public static Dictionary<string, double> GetSubjectAverages(List<StudentMarks> students)
        {
            return new Dictionary<string, double>()
            {
                {"Math", students.Average(x=> x.Math) },
                {"Science", students.Average(x=> x.Science)},
                {"English", students.Average(x=> x.English)}
            };
        }

        public static Dictionary<string, string> GetTopPerformers(List<StudentMarks> students)
        {
            return new Dictionary<string, string>()
            {
                {"Math", students.OrderByDescending(x=>x.Math).First().Name},
                {"Science", students.OrderByDescending(s=>s.Science).First().Name},
                {"English", students.OrderByDescending(e=>e.English).First().Name}
            };
        }

        public static List<string> GetConsistentPerformers(List<StudentMarks> students)
        {
            return students.Where(x => x.Science >= 80 && x.English >= 80 && x.Math >= 80)
                .Select(x => x.Name)
                .ToList();
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Student Marks Analyzer ===\n");

            // Create 8 students with realistic marks
            List<StudentMarks> students = new List<StudentMarks>
        {
            new StudentMarks { Name = "Alice", Math = 92, Science = 88, English = 90 },
            new StudentMarks { Name = "Bob", Math = 78, Science = 82, English = 85 },
            new StudentMarks { Name = "Carol", Math = 95, Science = 96, English = 94 },
            new StudentMarks { Name = "David", Math = 65, Science = 70, English = 68 },
            new StudentMarks { Name = "Eve", Math = 88, Science = 85, English = 87 },
            new StudentMarks { Name = "Frank", Math = 72, Science = 75, English = 73 },
            new StudentMarks { Name = "Grace", Math = 82, Science = 84, English = 86 },
            new StudentMarks { Name = "Henry", Math = 91, Science = 89, English = 93 }
        };

            Console.WriteLine("Student Records:");
            foreach (var student in students)
            {
                Console.WriteLine($"  {student}");
            }
            Console.WriteLine();

            // 1. Subject-wise marks grouping
            var subjectMarks = MarksAnalyzer.GroupBySubject(students);  // Fixed: Static call
            Console.WriteLine("=== SUBJECT-WISE MARKS DISTRIBUTION ===");
            foreach (var subject in subjectMarks)
            {
                Console.WriteLine($"{subject.Key}: {subject.Value.Count} students");
                Console.WriteLine($"  Range: {subject.Value.Min():F1} - {subject.Value.Max():F1}");
            }
            Console.WriteLine();

            // 2. Subject averages using Dictionary
            var averages = MarksAnalyzer.GetSubjectAverages(students);  // Fixed: Static call
            Console.WriteLine("=== SUBJECT AVERAGES ===");
            foreach (var avg in averages)
            {
                Console.WriteLine($"{avg.Key}: {avg.Value:F1}%");
            }
            Console.WriteLine();

            // 3. Top performers per subject
            var topPerformers = MarksAnalyzer.GetTopPerformers(students);  // Fixed: Static call
            Console.WriteLine("=== TOP PERFORMERS ===");
            foreach (var tp in topPerformers)
            {
                Console.WriteLine($"{tp.Key}: {tp.Value}");
            }
            Console.WriteLine();

            // 4. Consistent high achievers (>80% in ALL subjects)
            var consistentPerformers = MarksAnalyzer.GetConsistentPerformers(students);  // Fixed: Static call
            Console.WriteLine("=== CONSISTENT HIGH ACHIEVERS (>80% in ALL subjects) ===");
            if (consistentPerformers.Any())
            {
                foreach (var name in consistentPerformers)
                {
                    Console.WriteLine($"  {name}");
                }
            }
            else
            {
                Console.WriteLine("  None");
            }
        }
    }
}