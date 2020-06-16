using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBudgetApp.Model;
using Xamarin.Forms;

namespace UBudgetApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            var budgets = new List<Budget>();
            var files = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "budget.txt");
            foreach (var filename in files)
            {
                var budget = new Budget
                {
                    BudgetAmount = Convert.ToDouble(File.ReadAllText(filename)),
                    BudgetFile = filename
                };
                budgets.Add(budget);
            }
            if (budgets.Count != 0)
            {
                MessageStack.IsVisible = (budgets[0].BudgetAmount <= 0) ? true : false;
                BudgetView.IsVisible = (budgets[0].BudgetAmount <= 0) ? false : true;
                //AddExpenseButton.IsVisible = (budgets[0].BudgetAmount <= 0) ? false : true;
                ExpenseListButton.IsVisible = (budgets[0].BudgetAmount <= 0) ? false : true;
            }
            else
            {
                MessageStack.IsVisible = true;
                BudgetView.IsVisible = false;
                //AddExpenseButton.IsVisible = false;
                ExpenseListButton.IsVisible = false;
            }
            BudgetView.ItemsSource = budgets.ToList();
        }

        private async void AddExpenseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddExpense
            {
                BindingContext = new Expense()
            });
        }

        private async void ExpenseListButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ExpenseListPage
            {
                BindingContext = new Expense()
            });
        }

        private async void SetBudgetButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddBudgetPage
            {
                BindingContext = new Budget()
            }); ;
        }

        private async void BudgetView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new AddBudgetPage
            {
                BindingContext = new Budget()
            }); ;
        }
    }
}
