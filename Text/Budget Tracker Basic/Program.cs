using System;
using System.Collections.Generic;

var expenses = new List<Expense>
{
    new Expense(10.28, "Gas", string.Empty),
    new(34.65, "Food", "Shoprite"),
    new(300, "Savings", string.Empty),
    new(40.43, "Food", "Whole Foods")
};

bool isActive = true;

while(isActive)
{
    Console.WriteLine("========================");
    Console.WriteLine("Welcome to Budget Tracker");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("-add -showall -search");
    Console.WriteLine("========================");
    string userInput = Console.ReadLine();

    if(userInput == "-add")
    {
        AddItem();
    }
    else if(userInput == "-showall")
    {
        foreach(Expense item in expenses)
        {
            DisplayItem(item);
        }
    }
    else if(userInput == "-search")
    {
        Console.WriteLine("Enter category to search in");
        string categorySearch = Console.ReadLine();
        var results = Filter(expenses, e => e.Category.Equals(categorySearch));
        foreach(var result in results)
        {
            DisplayItem(result);
        }
    }
}


void AddItem()
{
    Console.Write("Enter Cost");
    string cost = Console.ReadLine();
    double costParse = Double.Parse(cost);
    Console.WriteLine("Enter Category");
    string category = Console.ReadLine();
    Console.WriteLine("Enter Notes");
    string notes = Console.ReadLine();

    expenses.Add(new Expense(costParse, category, notes));
}

void DisplayItem(Expense item)
{
    Console.WriteLine($"{item.Amount} {item.Category} {item.Notes}");
}


IEnumerable<Expense> Filter(IEnumerable<Expense> expenses, Filter f)
{
    foreach(var item in expenses)
    {
        if(f(item))
        {
            yield return item;
        }
    }
}

delegate bool Filter(Expense exp);

class Expense
{
    public Expense(double amount, string category, string notes)
    {
        this.Amount = amount;
        this.Category = category;
        this.Notes = notes;
    }
    public double Amount { get; set; }
    public string Category { get; set; }
    public string Notes { get; set; }
}