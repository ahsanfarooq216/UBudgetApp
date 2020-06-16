
using System;
using System.Collections.Generic;
using System.Text;
using UBudgetApp.Model;

namespace UBudgetApp
{
    public class AddExpenseViewModel
    {
        public Expense Expense { get; set; }

        public AddExpenseViewModel()
        {
            Expense = new Expense();


        }
    }
}