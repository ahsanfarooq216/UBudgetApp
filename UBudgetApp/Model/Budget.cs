using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UBudgetApp.Model
{
    public class Budget
    {
        public string BudgetFile { get; set; }
        public double BudgetAmount { get; set; }
        public double TotalExpenses { get; set; } = SumExpenses();
        public double RemainingBudget { get; set; } = ChooseBudget();
        public static double SumExpenses(){
            //listStart
            double totalExpenses = 0;
            var expenses = new List<Expense>();
            var expenseFiles = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");
            foreach (var filename in expenseFiles)
            {
                var expense = new Expense
                {
                    ExpenseFile = filename,
                    Amount = Convert.ToDouble(File.ReadLines(filename).Skip(1).Take(1).First())
                };

                expenses.Add(expense);
            }

            for (int i = 0; i < expenses.Count; i++)
            {
                totalExpenses += expenses[i].Amount;
            }
            //listView.ItemsSource = expenses.ToList();
            //listEnd
            return totalExpenses;
        }

        public static double ChooseBudget()
        {
            double remBudget = 0;
            if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "budget.txt")))
            {
                remBudget = Convert.ToDouble(File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "budget.txt"))) - SumExpenses();
            }
            return remBudget;
        }
    }

}
