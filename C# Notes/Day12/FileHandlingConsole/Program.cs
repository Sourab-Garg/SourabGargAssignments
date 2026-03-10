namespace FileHandlingConsole
{
    internal class Program
    {
        public static void readData()
        {
            FileStream fs = null;
            StreamReader sr;

            fs = new FileStream(@"C:\Drive\M.E\4th sem\Capgemini\Day12\FileHandlingConsole\sample.txt", FileMode.Open, FileAccess.Read);
            sr = new StreamReader(fs);
            sr.BaseStream.Seek(4, SeekOrigin.Begin);
            //first try above then put 200 and begin it will come 
            // put 200 and say end nothing will come 
            // put -200 and say end from backward direction it will read 
            // here first take the psotion to begin and after leaving 100 read it okay 
            // in the same manner current psotion by default will be begining only so again it 
            // will go to begining as current and after leaving 100 prrint all 
            // now if i write end then cussor will go to end point and after 100 spaces it will read
            // where of course data 
            // wont be there so u can do -100 and say end then curose will go 100 inside from back side
            // and after that
            // we  will read so this is the logic          
            string str = sr.ReadLine();
            while (str != null)
            {
                Console.WriteLine($"{str}");
                str = sr.ReadLine();


            }

        }
        public static void writedata()
        {
            // Define the path
            string path = @"C:\Drive\M.E\4th sem\Capgemini\Day12\FileHandlingConsole\sample.txt";

            try
            {
                // The 'using' block ensures the file is released as soon as the code finishes
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        Console.WriteLine("Enter text to write to the file:");
                        string input = Console.ReadLine();

                        // Write the data
                        sw.WriteLine(input);

                        // Since you want to use Flush:
                        // This pushes data from the memory buffer to the physical disk.
                        sw.Flush();

                        Console.WriteLine("Data flushed and saved successfully.");

                    } // <--- sw.Close() and sw.Dispose() happen automatically here
                } // <--- fs.Close() and fs.Dispose() happen automatically here
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Error: You do not have permission to write to this folder.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"File error: {ex.Message}");
            }
        }
        static void Main(string[] args)
        {
            writedata();
            readData();
            
            Console.ReadLine();       
        }
    }
}
