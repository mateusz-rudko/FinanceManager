using Inzynierka.Models;
using Inzynierka.Popups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePage : ContentPage
    {
        private Transaction _transaction;
        public List<string> Categories = new List<string>()
            {
                "Groceries",
                "Car Maintenance",
                "Salary",
                "Services",
                "Gadgets",
            };
        public UpdatePage(Transaction transaction)
        {
            _transaction = transaction;
            InitializeComponent();
            
            Entry nameEntry = this.FindByName<Entry>("nameEntry");
            Entry priceEntry = this.FindByName<Entry>("priceEntry");
            Entry descriptionEntry = this.FindByName<Entry>("descriptionEntry");
            Picker categoryPicker = this.FindByName<Picker>("categoryPicker");
            DatePicker datePicker = this.FindByName<DatePicker>("datePicker");
            nameEntry.Text = transaction.Name;
            priceEntry.Text = transaction.Price.ToString();
            descriptionEntry.Text = transaction.Description;
            //categoryPicker.SelectedItem = transaction.Category.ToString();
            datePicker.Date=transaction.Date;
            categoryPicker.ItemsSource = Categories;
            //categoryPicker.SelectedItem = SelectedCategory;
            Console.WriteLine(nameEntry.Text);
            Console.WriteLine(priceEntry.Text);
            Console.WriteLine(descriptionEntry.Text);
            Console.WriteLine(categoryPicker.SelectedItem);
            Console.WriteLine(datePicker.Date);

        }
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            int numModals = Application.Current.MainPage.Navigation.ModalStack.Count;
            for (int currModal = 0; currModal < numModals; currModal++)
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
            //await Navigation.PopModalAsync();
        }
        private void UpdateButtonClicked(object sender, EventArgs e)
        {
            
            _transaction.Name = nameEntry.Text;
            _transaction.Price = float.Parse(priceEntry.Text);
            _transaction.Description = descriptionEntry.Text;
            _transaction.Category = categoryPicker.SelectedItem.ToString();
            _transaction.Date = datePicker.Date;
            //await App.Database.UpdateTransaction(_transaction);
            Navigation.ShowPopup(new UpdatePopup(_transaction));
            
        }
    }
}