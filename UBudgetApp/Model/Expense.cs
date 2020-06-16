using System;
using System.Collections.Generic;
using System.Text;

namespace UBudgetApp.Model
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public string ExpenseFile { get; set; }
        public string ExpenseName { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string PictureUrl { get; set; }


        //public Expense(int expenseId, string expenseName, double amount, DateTime date, string category, string pictureUrl)
        //{
        //    ExpenseId = expenseId;
        //    ExpenseName = expenseName;
        //    Amount = amount;
        //    Category = category;
        //    Date = date;
        //    PictureUrl = pictureUrl;
        //}

        public Expense()
        {
        }
    }
}
