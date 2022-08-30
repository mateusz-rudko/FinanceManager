using Inzynierka.Models;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AccountPage : ContentPage
    {
       
        public AccountPage()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var historyList = await App.Database.GetAllTransactionsAsync();
            if(historyList != null)
                HistoryList.ItemsSource = historyList;
        }
        private async void IncomeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewIncomePage()));
        }
        private async void ExpenseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewExpensePage()));
        }

        async void HistoryItem_Tapped(object sender, EventArgs e)
        {
            Transaction transaction = HistoryList.SelectedItem as Transaction;
           


            await Navigation.PushModalAsync(new HistoryRecordPage(transaction));
        }
        async void NotificationPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NotificationsPage()));
        }


    }
}