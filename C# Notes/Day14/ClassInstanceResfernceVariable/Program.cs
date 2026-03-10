namespace ClassInstanceResfernceVariable
{ 
    class car
{
    public string brand;// instance varibale for every obj a copy is aviable 
    public int speed;//instance varibale for every obj there is a copy aviable 

    public static int totalcars = 0;//class varibale all object share this class variable 
    public car(string brand, int speed)
    {
        this.brand = brand;
        this.speed = speed;
        totalcars++;
    }
    public car()
    {
        Console.WriteLine($"Right now totak cars :{totalcars}");
    }
}
internal class Program
{
    static void Main(string[] args)
    {

        car car1 = new car("Toyato", 100);
        car car2 = new car("Honda", 110);  
        car car3 = car1;
            Console.WriteLine(car1.brand);
            Console.WriteLine(car2.brand);
            Console.WriteLine(car3.brand);
        Console.WriteLine($"{car.totalcars}");

    }
}
}