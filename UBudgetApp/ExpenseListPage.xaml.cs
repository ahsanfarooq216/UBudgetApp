using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UBudgetApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UBudgetApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpenseListPage : ContentPage
    {
        public ExpenseListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            //listStart
            var expenses = new List<Expense>();
            var expenseFiles = Directory.EnumerateFiles(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "*.expense.txt");
            foreach (var filename in expenseFiles)
            {
                var expense = new Expense
                {
                    ExpenseFile = filename,
                    ExpenseName = File.ReadLines(filename).First(),
                    Amount = Convert.ToDouble(File.ReadLines(filename).Skip(1).Take(1).First()),
                    Date = Convert.ToDateTime(File.ReadLines(filename).Skip(2).Take(1).First()),
                    Category = File.ReadLines(filename).Skip(3).Take(1).First(),
                    PictureUrl = File.ReadLines(filename).Skip(4).Take(1).First()
                };

                expenses.Add(expense);
            }
            listView.ItemsSource = expenses.ToList();
            //listEnd
        }
        private void AddExpenseButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddExpense());
        }
        private void RemoveTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            TappedEventArgs tappedEventArgs = (TappedEventArgs)e;


            Expense expense = ((ExpenseListViewModel)BindingContext).
                Expenses.Where(exp => exp.ExpenseId == (int)tappedEventArgs.Parameter).FirstOrDefault();
            ((ExpenseListViewModel)BindingContext).Expenses.Remove(expense);
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushModalAsync(new AddExpense
                {
                    BindingContext = (Expense)e.SelectedItem
                });
            }
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}










