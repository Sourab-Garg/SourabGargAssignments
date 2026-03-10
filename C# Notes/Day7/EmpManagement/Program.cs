using System;

namespace EmpManagememnt
{
    // Interface remains the same (Interfaces define methods, not fields)
    public interface IWork
    {
        void PerformWork();
        bool RequestLeave(int days);
    }

    // 1. Abstract class using Fields instead of Properties
    public abstract class Employee
    {
        public string Name;        // Field
        public string EmployeeID;  // Field

        public abstract double CalculateSalary();

        public virtual void DisplayEmployeeInfo()
        {
            Console.WriteLine($"Employee ID : {EmployeeID}");
            Console.WriteLine($"Name        : {Name}");
        }
    }

    // 2a. PermanentEmployee
    public class PermanentEmployee : Employee, IWork
    {
        public double BasicSalary;
        public double Benefits;

        public override double CalculateSalary()
        {
            return BasicSalary + Benefits;
        }

        public void PerformWork()
        {
            Console.WriteLine("Permanent Employee is working on long-term projects.");
        }

        public bool RequestLeave(int days)
        {
            return days <= 30;
        }
    }

    // 2b. ContractEmployee
    public class ContractEmployee : Employee, IWork
    {
        public double HourlyRate;
        public int HoursWorked;

        public override double CalculateSalary()
        {
            return HourlyRate * HoursWorked;
        }

        public void PerformWork()
        {
            Console.WriteLine("Contract Employee is working on short-term tasks.");
        }

        public bool RequestLeave(int days)
        {
            return days <= 10;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Since we removed get/set, we assign values directly to the fields
            PermanentEmployee pe = new PermanentEmployee();
            pe.Name = "Rahul";
            pe.EmployeeID = "PE101";
            pe.BasicSalary = 50000;
            pe.Benefits = 10000;

            Console.WriteLine("---- Permanent Employee ----");
            pe.DisplayEmployeeInfo();
            pe.PerformWork();
            Console.WriteLine("Salary: " + pe.CalculateSalary());

            Console.WriteLine();

            ContractEmployee ce = new ContractEmployee();
            ce.Name = "Amit";
            ce.EmployeeID = "CE201";
            ce.HourlyRate = 500;
            ce.HoursWorked = 120;

            Console.WriteLine("---- Contract Employee ----");
            ce.DisplayEmployeeInfo();
            ce.PerformWork();
            Console.WriteLine("Salary: " + ce.CalculateSalary());

            Console.ReadLine();
        }
    }
}