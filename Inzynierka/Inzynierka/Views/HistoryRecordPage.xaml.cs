using Inzynierka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inzynierka.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryRecordPage : ContentPage
    {
        private Transaction _transaction;
        public HistoryRecordPage(Transaction transaction)
        {
            _transaction = transaction;
            InitializeComponent();
   
            Label nameLabel = this.FindByName<Label>("nameLbl");
            Label priceLabel = this.FindByName<Label>("priceLbl");
            Label categoryLabel = this.FindByName<Label>("categoryLbl");
            Label descriptionLabel = this.FindByName<Label>("descriptionLbl");
            Label isIncomeLabel = this.FindByName<Label>("isIncomeLbl");
            Label dateLabel = this.FindByName<Label>("dateLbl");
                     
            nameLabel.Text = transaction.Name;
            priceLabel.Text = transaction.Price.ToString();
            categoryLabel.Text = transaction.Category;
            descriptionLabel.Text = transaction.Description;
            isIncomeLabel.Text = transaction.IsIncome.ToString();
            dateLabel.Text = transaction.Date.ToString();
            if (isIncomeLabel.Text == "False")
            {
                Expense.IsVisible = true;
                Income.IsVisible = false;
            }
            else
            {
                Expense.IsVisible = false;
                Income.IsVisible = true;
            }

        }
        
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void DeleteButtonClicked(object sender, EventArgs e)
        {

            await App.Database.RemoveTransaction(_transaction);
          

            await Navigation.PopModalAsync();

        }
        private async void UpdateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new UpdatePage());
        }
    }
}