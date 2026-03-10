namespace LinqToFileDemo
{
    public class MyFileInfo
    {
        public string Name { get; set; }
        public long length { get; set; }
        public DateTime CreationTime { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var files = from file in new DirectoryInfo(@"C:\Windows").GetFiles()
                        where file.Length > 10
                        orderby file.Length descending
                        select new MyFileInfo
                        {
                            Name = file.Name,
                            length = file.Length,
                            CreationTime = file.CreationTime
                        };
            var files1 = new DirectoryInfo(@"C:\Windows").GetFiles()
                        .Where(file => file.Length > 10)
                        .OrderByDescending(file => file.Length)
                        .Select(f => new MyFileInfo
                        {
                            Name = f.Name,
                            length = f.Length,
                            CreationTime = f.CreationTime
                        });
            foreach (var file in files)
            {
                Console.WriteLine($"{file.Name} {file.length} {file.CreationTime}");
            }
        }
    }
}