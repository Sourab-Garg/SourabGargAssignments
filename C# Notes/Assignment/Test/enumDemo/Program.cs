namespace enumDemo
{

    enum Priority { Low, Med, High };
    class Task
    {
        public string taskName;
        public Priority taskPriority;

        public void showTask()
        {
            Console.WriteLine($"Task Name: {taskName}");
            switch (taskPriority)
            {
                case Priority.High:
                    Console.WriteLine("Action: Move to top of the list!");
                    break;
                case Priority.Med:
                    Console.WriteLine("Action: Complete by end of week.");
                    break;
                case Priority.Low:
                    Console.WriteLine("Action: Backlog item.");
                    break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Task t1 = new Task();
            t1.taskName = "AWS";
            t1.taskPriority = Priority.High;

            t1.showTask();

            t1.taskPriority = Priority.Low;
            t1.showTask();
            Console.ReadLine();
        }
    }
}
