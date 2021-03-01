using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace Budget_Tracker
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(@"Server=.;Database=ExpenseTest;Trusted_Connection=True;");
        }
        
    }

    public class Expense
    {
        public Expense(double amount, string category, string notes)
        {
            Amount = amount;
            Category = category;
            Notes = notes;
        }
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public string Notes { get; set; }

    }
}
