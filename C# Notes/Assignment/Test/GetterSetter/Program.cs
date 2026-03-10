namespace GetterSetter
{
    public class Car
    {
        private int _speed;

        public Car(int initialSpeed)
        {
           Speed = initialSpeed;
        }

        public int Speed
        {
            get { return  _speed; }
            set 
            { 
                if( value > 150)
                {
                    _speed = 150;
                }
                else
                {
                    _speed = value;
                }
            }
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Car c1 = new Car(1222);

            Console.WriteLine(c1.Speed);

            Console.ReadLine();
        }
    }
}
