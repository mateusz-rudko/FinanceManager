using Inzynierka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePopup : Popup
    {
        private Transaction _transaction;
        public UpdatePopup(Transaction transaction)
        {
            _transaction = transaction;
            InitializeComponent();
           
        }
        
        private async void YesButtonClicked(object sender, EventArgs e)
        {
            await App.Database.UpdateTransaction(_transaction);
            Dismiss(null);
            Console.WriteLine("GOWBNO SDSADJSAKLDJSALKJDSAKLDJA" + _transaction.Name.ToString());

        }
        private void NoButtonClicked(object sender, EventArgs e)
        {
            
            Dismiss(new UpdatePopup(_transaction));
        }
    }
}