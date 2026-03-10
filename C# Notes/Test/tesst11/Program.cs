namespace tesst11
{
    public static class UserRegistry
    {
        public static int UserCount = 0;

        public static void TotalUsers()
        {
            Console.WriteLine($"Total Users: {UserCount}");
        }
    }
    public class User
    {
        public string UserName { get; set; }

        public User()
        {
            UserRegistry.UserCount++;
        }
        public virtual void GetPermission()
        {
            Console.WriteLine("Permission Given");
        }   
    }
    public sealed class Admin : User
    {
        public override sealed void GetPermission()
        {
            Console.WriteLine("Permission Given");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            UserRegistry.TotalUsers();
            User u1 = new User();
            User u2 = new User();
            User u3 = new User();
            UserRegistry.TotalUsers();
            Admin a1 = new Admin();
            Admin a2 = new Admin();
            UserRegistry.TotalUsers();

            Console.ReadLine();
        }
    }
}
