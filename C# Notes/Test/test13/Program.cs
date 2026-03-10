namespace test13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int x = 10;
                int y = 0;
                int res = x / y;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cant divide number by 0");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid Format");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception");
            }
            finally
            {
                Console.WriteLine("Operation Complete");
            }

            Console.ReadLine();
        }
    }
}
