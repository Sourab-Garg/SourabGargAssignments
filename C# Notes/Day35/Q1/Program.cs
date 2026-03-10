namespace Q1
{
    public abstract class Vehicle
    {
        protected double Milage { set; get; }
        protected int Seats { set; get; }

        public Vehicle(int milage, int seats)
        {
            Milage = milage;
            Seats = seats;
        }
        public abstract double GetFuelEfficiency();
        public virtual string GetVehicleInfo()
        {
            return $"{GetType().Name} Efficiency {GetFuelEfficiency()}";
        }

    }
    public class PetrolCar: Vehicle
    {
        public PetrolCar(int Milage, int Seats):base(Milage, Seats)
        {
     
        }
        public override double GetFuelEfficiency()
        {
            return Milage;
        }
    }
    public class DieselBus: Vehicle
    {
        public DieselBus(int Milage, int Seats) : base(Milage, Seats)
        {

        }
        public override double GetFuelEfficiency()
        {
            return Milage*0.8;
        }
    }
    public class ElectricCar: Vehicle
    {
        protected int BatteryCapacity { set; get; }
        public ElectricCar(int Milage, int Seats, int batteryCapacity) : base(Milage, Seats)
        {
            BatteryCapacity = batteryCapacity;
        }
        public override double GetFuelEfficiency()
        {
            return (double)BatteryCapacity/Seats;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> list = new List<Vehicle>
            {
                new PetrolCar(15,4),
                new DieselBus(10,40),
                new ElectricCar(0,5,75)
            };
            foreach (Vehicle v in list)
            {
                Console.WriteLine(v.GetVehicleInfo());
            }
            double avg = Math.Round(list.Average(x => x.GetFuelEfficiency()),2);
            Console.WriteLine($"Average: {avg}");
            
            Console.ReadLine();
        }
    }
}
