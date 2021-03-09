using System;
using System.Collections.Generic;

/*Company Manager 
 * Create an hierarchy of classes 
 * abstract class Employee and subclasses HourlyEmployee, SalariedEmployee, Manager and Executive. 
 * Every one's pay is calculated differently, research a bit about it. 
 * 
 * After you've established an employee hierarchy, create a Company class that allows you to manage the employees. 
 * 
 * 
 * Still to DO:
 * You should be able to hire, fire and raise employees.
 
 */

class Program
{
    static void Main(string[] args)
    {
        Company newrl = new();
        newrl.EveryoneSayHello();
    }
}

class Company
{
    //To do - clean this up here
    private List<Employee> employees = new();
    private List<Employee> Employees { get => employees; set => employees = value; }

    public Company()
    {
        var defaultEmployees = new List<Employee>
        {
            new HourlyEmployee("Bill", 15),
            new SalariedEmployee("Jeff", 1500),
            new Manager("Steven", 3000, 5000)
        };

        foreach(var employee in defaultEmployees)
        {
            Employees.Add(employee);
        }  
    }
    public void EveryoneSayHello()
    {
        foreach (var person in Employees)
        {
            person.SayHello();
        }
    }
}

interface IEmployee
{
    public string Name { get; set; }
    public int YearlyPay { get; set; }
    public string TypeOfEmployee { get; set; }
    void SayHello();
    int CalculatePay();
}
abstract class Employee : IEmployee
{
    public string Name { get; set; }
    public string TypeOfEmployee { get; set; }
    public int YearlyPay
    {
        get
        {
            return CalculatePay();
        }
        set
        {
            YearlyPay = value;
        }
    }

    public void SayHello()
    {
        Console.WriteLine($"Hi my name is { Name } and I make { YearlyPay } a year, I work as an {TypeOfEmployee}");
    }

    public abstract int CalculatePay();
}

class HourlyEmployee : Employee
{
    public int HourlyRate { get; set; }
    public HourlyEmployee(string name, int hourlyRate)
    {
        Name = name;
        HourlyRate = hourlyRate;
        // todo - Find better solution for this. Shouldnt need to call this in every class
        TypeOfEmployee = GetType().ToString();
    }
    public override int CalculatePay()
    {
        return HourlyRate * 2080;
    }
}

class SalariedEmployee : Employee
{
    public int WeeklyRate { get; set; }

    public SalariedEmployee(string name, int weeklyRate)
    {
        Name = name;
        WeeklyRate = weeklyRate;
        TypeOfEmployee = GetType().ToString();
    }

    public override int CalculatePay()
    {
        return WeeklyRate * 52;
    }
}

class Manager : Employee
{
    public int WeeklyRate { get; set; }
    public int YearlyBonus { get; set; }

    public Manager(string name, int weeklyRate, int yearlyBonus)
    {
        Name = name;
        WeeklyRate = weeklyRate;
        YearlyBonus = yearlyBonus;
        TypeOfEmployee = GetType().ToString();
    }
    public override int CalculatePay()
    {
        return (WeeklyRate * 52) + YearlyBonus;
    }
}