using System;
using Inzynierka.Models;
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
    public partial class DeleteNotificationPopup : Popup
    {
        private Notifications _notification;
        public DeleteNotificationPopup(Notifications notification)
        {
            _notification = notification;
            InitializeComponent();
            
        }
        private async void YesButtonClicked(object sender, EventArgs e)
        {
            await App.NotoficationsDatabase.RemoveNotification(_notification);
            Dismiss(null);
            await Application.Current.MainPage.Navigation.PopModalAsync();

        }
        private void NoButtonClicked(object sender, EventArgs e)
        {
            Dismiss(new DeleteNotificationPopup(_notification));
        }
    }
}