using System;

/*Company Manager 
 * Create an hierarchy of classes 
 * abstract class Employee and subclasses HourlyEmployee, SalariedEmployee, Manager and Executive. 
 * Every one's pay is calculated differently, research a bit about it. 
 * 
 * After you've established an employee hierarchy, create a Company class that allows you to manage the employees. 
 * You should be able to hire, fire and raise employees.
 
 */

class Program
{
    static void Main(string[] args)
    {
        HourlyEmployee bill = new("Bill", 15);
        bill.SayHello();
        SalariedEmployee jeff = new("Jeff", 1500);
        jeff.SayHello();
        Manager steven = new("Steven", 3000, 5000);
        steven.SayHello();
    }
}

abstract class Employee
{
    public string Name { get; set; }

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
        Console.WriteLine($"Hi my name is { Name } and I make { YearlyPay } a year");
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
    }

    public override int CalculatePay()
    {
        return (WeeklyRate * 52) + YearlyBonus;
    }
}