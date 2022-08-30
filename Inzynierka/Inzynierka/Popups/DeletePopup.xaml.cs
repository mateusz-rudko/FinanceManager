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
    public partial class DeletePopup : Popup
    {
        private Transaction _transaction;
        public DeletePopup(Transaction transaction)
        {
            _transaction = transaction;
            InitializeComponent();
            
        }
        private void YesButtonClicked(object sender, EventArgs e)
        {
            App.Database.RemoveTransaction(_transaction);
            Dismiss(null);
            Application.Current.MainPage.Navigation.PopModalAsync();    
        }
        private void NoButtonClicked(object sender, EventArgs e)
        {
            Dismiss(new DeletePopup(_transaction));
        }
    }
}