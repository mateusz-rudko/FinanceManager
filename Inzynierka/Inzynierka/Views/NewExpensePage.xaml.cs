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
        public List<string> Categorys = new List<string>()
            {
                "Zakupy spożywcze",
                "Utrzymanie auta",
                "Salary",
                "Services",
                "Food",
                "Gadgets",
                "Persons"

            };
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void SubmitButtonClicked(object sender, EventArgs e)
        {
            if (NameEntry.Text != null && PriceEntry.Text!=null && CategoryPicker.SelectedItem!=null && DatePicker.Date!=null)
            {
                Console.WriteLine(NameEntry.Text);
                Console.WriteLine(PriceEntry.Text);
                Console.WriteLine(CategoryPicker.SelectedItem);
                Console.WriteLine(DatePicker.Date);
            }
            else
            {
                Console.WriteLine("XD");
            }
        }
        public NewExpensePage()
        {
            InitializeComponent();
            CategoryPicker.ItemsSource = Categorys;
            CategoryPicker.SelectedItem = SelectedCategory;
            DatePicker.Date = Date;

        }

        
    }
}