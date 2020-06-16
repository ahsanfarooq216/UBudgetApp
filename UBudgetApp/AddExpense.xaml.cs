
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
    public partial class AddExpense : ContentPage
    {
        public AddExpense()
        {
            InitializeComponent();
        }
        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Expense expense = ((AddExpenseViewModel)BindingContext).Expense;
            if (string.IsNullOrWhiteSpace(expense.ExpenseFile))
            {
                //create and save expense
                var filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    $"{Path.GetRandomFileName()}.expense.txt");
                File.AppendAllText(filename, $"{NameEntry.Text}\n");
                File.AppendAllText(filename, $"{AmountEntry.Text}\n");
                File.AppendAllText(filename, $"{DatePicker.Date}\n");
                File.AppendAllText(filename, $"{CategoryPicker.SelectedItem}\n");
                File.AppendAllText(filename, $"{IconAddress($"{CategoryPicker.SelectedItem}")}");
            }
            else
            {
                //update existing expense
                File.WriteAllText(expense.ExpenseFile, $"{NameEntry.Text}\n");
                File.AppendAllText(expense.ExpenseFile, $"{AmountEntry.Text}\n");
                File.AppendAllText(expense.ExpenseFile, $"{DatePicker.Date}\n");
                File.AppendAllText(expense.ExpenseFile, $"{CategoryPicker.SelectedItem}\n");
                File.AppendAllText(expense.ExpenseFile, $"{IconAddress($"{CategoryPicker.SelectedItem}")}");
            }

            MessagingCenter.Send(this, "AddExpense", expense);
            await Navigation.PopModalAsync();
        }
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var expense = (Expense)BindingContext;
            if (File.Exists(expense.ExpenseFile))
            {
                File.Delete(expense.ExpenseFile);
            }
            //To go back to previous page
            await Navigation.PopModalAsync();
        }
        private void SelectedDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var NewDate = e.NewDate.ToShortDateString();
        }

        public static string IconAddress(string cat)
        {
            string IconAddress = "";
            switch (cat)
            {
                case "Transport":
                    IconAddress = "Assets/Icons/autoNTransport.png";
                    break;
                case "Education":
                    IconAddress = "Assets/Icons/education.png";
                    break;
                case "Entertainment":
                    IconAddress = "Assets/Icons/entertainment.png";
                    break;
                case "Eating Out":
                    IconAddress = "Assets/Icons/foodNDining.png";
                    break;
                case "Gifts":
                    IconAddress = "Assets/Icons/gifts.png";
                    break;
                case "Health":
                    IconAddress = "Assets/Icons/healthNFitness.png";
                    break;
                case "Kids":
                    IconAddress = "Assets/Icons/kids.png";
                    break;
                case "Miscellaneous":
                    IconAddress = "Assets/Icons/miscellaneous.png";
                    break;
                case "Personal Care":
                    IconAddress = "Assets/Icons/personalCare.png";
                    break;
                case "Shopping":
                    IconAddress = "Assets/Icons/shopping.png";
                    break;
                case "Travel":
                    IconAddress = "Assets/Icons/travel.png";
                    break;
                case "Utilities":
                    IconAddress = "Assets/Icons/utilities.png";
                    break;
            }
            return IconAddress;
        }

        private async void OnCancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}

