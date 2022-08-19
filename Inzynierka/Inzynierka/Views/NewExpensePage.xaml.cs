using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inzynierka.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewExpensePage : ContentPage
    {
        public string SelectedCategory { get; set; }
        public DateTime DateTime { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public List<string> Categories = new List<string>()
            {
                "Groceries",
                "Car Maintenance",
                "Salary",
                "Services",
                "Gadgets",
            };
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (nameEntry.Text != null && priceEntry.Text!=null &&  categoryPicker.SelectedItem!=null && datePicker.Date!=null) 
            {
                //Console.WriteLine("date "+ Convert.ToDateTime(datePicker.Date.ToString("dd/MM/yyyy")));
                await App.Database.AddNewTransaction(new Transaction
                {
                    Name = nameEntry.Text,
                    Price = float.Parse(priceEntry.Text),
                    Description = descriptionEntry.Text,
                    Category = categoryPicker.SelectedItem.ToString(),
                    Date = Convert.ToDateTime(datePicker.Date.ToShortDateString()),
                    IsIncome = false
                }) ;

                await Navigation.PopModalAsync();

                Console.WriteLine(nameEntry.Text);
                Console.WriteLine(priceEntry.Text);
                Console.WriteLine(categoryPicker.SelectedItem);
                Console.WriteLine(datePicker.Date);
            }
            else
            {
                Console.WriteLine("XD");
                Console.WriteLine();
            }
        }
        public NewExpensePage()
        {
            InitializeComponent();
            categoryPicker.ItemsSource = Categories;
            categoryPicker.SelectedItem = SelectedCategory;
            datePicker.Date = Date;

        }

        
    }
}