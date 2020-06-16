using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UBudgetApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //MainPage = new AddExpense();
            //MainPage = new AddBudgetPage();
            //MainPage = new ExpenseListPage();

          
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
