using System;
using System.Collections.Generic;
using System.Linq;

namespace Budget_Tracker
{
    class Program
    {
        static void Main(string[] args)
        {
            /*GenerateDefaultData();*/
            bool appActive = true;

            Console.WriteLine("=======Budget Tracker==========");
            Console.WriteLine("      -h or -help for cmds");

            while(appActive)
            {
                ShowAll();
                Console.Write("> ");
                string userInput = Console.ReadLine();

                if(userInput == "-add")
                {
                    AddExpense();
                }
                else if(userInput == "-edit")
                {
                    Console.Write("Enter Id for expense to edit: ");
                    userInput = Console.ReadLine();
                    int editId = Int32.Parse(userInput);
                    UpdateItem(editId);
                }

                else if (userInput == "-remove")
                {
                    Console.Write("Enter Id for expense to Delete: ");
                    userInput = Console.ReadLine();
                    int deleteId = Int32.Parse(userInput);
                    DeleteExpense(deleteId);
                }

                Console.Clear();
            }
        }

        static void AddExpense()
        {
            using (var db = new ApplicationDbContext())
            {
                Console.Write("Cost: ");
                string costInput = Console.ReadLine();
                double cost = Double.Parse(costInput);

                Console.Write("Category: ");
                string category = Console.ReadLine();

                Console.Write("Notes: ");
                string notes = Console.ReadLine();

                db.Add(new Expense(cost, category, notes));
                db.SaveChanges();
            }
        }

        static void UpdateItem(int item)
        {
            using (var db = new ApplicationDbContext())
            {
                Expense expense = db.Expenses.Find(item);

                Console.Write("Cost: ");
                string costInput = Console.ReadLine();
                expense.Amount = Double.Parse(costInput);

                Console.Write("Category: ");
                expense.Category = Console.ReadLine();

                Console.Write("Notes: ");
                expense.Notes = Console.ReadLine();

                db.SaveChanges();
            } 
        }

        static void DeleteExpense(int item)
        {
            using (var db = new ApplicationDbContext())
            {
                Expense expense = db.Expenses.Find(item);
                db.Expenses.Remove(expense);
                db.SaveChanges();
            }
        }
        

        static void ShowAll()
        {
            using (var db = new ApplicationDbContext())
            {
                List<Expense> expenses = db.Expenses.ToList();
                foreach(var item in expenses)
                {
                    DisplayItem(item);
                }
            }
        }

        static void DisplayItem(Expense item)
        {
            Console.WriteLine($"{item.Id} - {item.Amount} - {item.Category} - {item.Notes}");
        }
        static void GenerateDefaultData()
        {
            using (var db = new ApplicationDbContext())
            {
                var expenses = new List<Expense>
                {
                    new Expense(10.28, "Gas", string.Empty),
                    new(34.65, "Food", "Shoprite"),
                    new(300, "Savings", string.Empty),
                    new(40.43, "Food", "Whole Foods")
                };

                foreach (var expense in expenses)
                {
                    db.Add(expense);
                }
                db.SaveChanges();
            }
        }
    }
}
