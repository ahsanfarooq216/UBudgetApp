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
    public partial class AddBudgetPage : ContentPage
    {
        public AddBudgetPage()
        {
            InitializeComponent();
        }

        private async void SaveBudgetButton_Clicked(object sender, EventArgs e)
        {
            var budget = (Budget)BindingContext;
            if (string.IsNullOrWhiteSpace(budget.BudgetFile))
            {
                //create and save budget
                var budgetFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "budget.txt");
                File.WriteAllText(budgetFile, BudgetAmountEntry.Text);
            }
            else
            {
                //update existing budget
                File.WriteAllText(budget.BudgetFile, BudgetAmountEntry.Text);
            }
            await Navigation.PopModalAsync();
        }

        private async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}