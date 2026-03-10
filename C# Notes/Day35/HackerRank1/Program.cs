using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HackerRank1
{
    abstract class Car
    {
        protected bool IsSedan {  get; set; } 
        protected string Seats { get; set; }

        public Car() { }

        public Car(bool isSedan, string seats)
        {
            IsSedan = isSedan;
            Seats = seats;
        }

        public bool getIsSedan()
        {
            return IsSedan;
        }

        public string getSeats()
        {
            return this.Seats;
        }

        abstract public string getMileage();

        public void printCar(string name)
        {
            Console.WriteLine("A {0} is{1} Sedan, is {2}-seater, and has a mileage of around {3}.",
            name,
            getIsSedan() ? "" : " not",
            getSeats(),
            getMileage());
        }
    }

    // Write your code here.

    class WagonR : Car
    {
        public int CarMilage { get; set; }
        public WagonR(int carMilage) : base(false, "4")
        { 
            CarMilage = carMilage;
        }
        public override string getMileage()
        {
            return $"{CarMilage} kmph";
        }
    }
    class HondaCity : Car
    {
        public int CarMilage { get; set; }
        public HondaCity(int carMilage) : base(true, "4")
        {
            CarMilage = carMilage;
        }
        public override string getMileage()
        {
            return $"{CarMilage} kmph";
        }
    }
    class InnovaCrysta : Car
    {
        public int CarMilage { get; set; }
        public InnovaCrysta(int carMilage) : base(false, "6")
        {
            CarMilage = carMilage;
        }
        public override string getMileage()
        {
            return $"{CarMilage} kmph";
        }
    }

    class Solution
    {
        static void Main(string[] args)
        {
            int carType = Convert.ToInt32(Console.ReadLine().Trim());
            int carMileage = Convert.ToInt32(Console.ReadLine().Trim());

            if (carType == 0)
            {
                Car wagonR = new WagonR(carMileage);
                wagonR.printCar("WagonR");
            }

            if (carType == 1)
            {
                Car hondaCity = new HondaCity(carMileage);
                hondaCity.printCar("HondaCity");
            }

            if (carType == 2)
            {
                Car innovaCrysta = new InnovaCrysta(carMileage);
                innovaCrysta.printCar("InnovaCrysta");
            }
        }
    }
}