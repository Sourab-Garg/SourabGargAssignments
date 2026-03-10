namespace Test9
{
    public class LibraryItem 
    {
        public string Title { get; set; }
        public int Id { get; set; }
        public bool IsAvailable { get; set; }
        public LibraryItem(string title, int id, bool isAvailable) 
        {
            Title = title;
            Id = id;
            IsAvailable = isAvailable;
        }
    }
    public class Book : LibraryItem
    {
        public string Name { get; set; }
        public Book(string title, int id, bool isAvailable, string name):base(title, id, isAvailable)
        {
            Name = name;
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("c#", 1, true, "RS GOA");
            LibraryItem l1 = new LibraryItem("c++", 2, true);

            Console.WriteLine(b1.Title);
            Console.WriteLine(l1.Title);

            Console.ReadLine();
        }
    }
}
