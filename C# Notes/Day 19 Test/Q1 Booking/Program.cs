namespace Q1_Booking
{
    internal class Program
    {
        public class SeatNotAvailableException : Exception
        {
            public SeatNotAvailableException() : base("SeatNotAvailabelException: This seat is already booked.") { }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter total seats of bus: ");
                int size = Convert.ToInt32(Console.ReadLine());

                int[] arr = new int[size];

                Console.WriteLine("Enter number of seats to be booked: ");
                int seats = Convert.ToInt32(Console.ReadLine());

                if (seats > size || seats < 0)
                {
                    Console.WriteLine("Invalid Seat Space.");
                    return;
                }

                for (int i = 0; i < seats; i++)
                {
                    try
                    {
                        Console.WriteLine($"\nBooking ticket {i + 1} of {seats}. Enter seat number:");
                        int tempseat = Convert.ToInt32(Console.ReadLine());

                        if (tempseat > size || tempseat <= 0)
                        {
                            Console.WriteLine($"Invalid Seat option. Please pick between 1 and {size}");
                            i--;
                            continue;
                        }

                        if (arr[tempseat - 1] == 1)
                        {
                            throw new SeatNotAvailableException();
                        }

                        Console.WriteLine($"Seat number {tempseat} booked successfully!");
                        arr[tempseat - 1] = 1;
                    }
                    catch (SeatNotAvailableException ex)
                    {
                        Console.WriteLine(ex.Message);
                        i--; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nThank you!");
            }

            Console.ReadLine();
        }
    }
}