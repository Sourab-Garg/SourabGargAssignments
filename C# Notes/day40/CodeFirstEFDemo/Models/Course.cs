using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public CourseLevel level { get; set; }
        public List<Student> Students { get; set; }
        public Author Author { get; set; }
        public int AuthorId { get; set; }
    }
    public enum CourseLevel
    {
        Beginner = 1,
        Average = 2,
        Difficult = 3
    }
}
