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
    public partial class NotificationRecordPage : ContentPage
    {
        private Notifications _notification;
        public NotificationRecordPage(Notifications notification)
        {
            _notification = notification;
            InitializeComponent();
            Label nameLabel = this.FindByName<Label>("nameLbl");
            Label descriptionLabel = this.FindByName<Label>("descriptionLbl");
            Label dateLabel = this.FindByName<Label>("dateLbl");
            nameLabel.Text = notification.Name;
            descriptionLabel.Text = notification.Description;
            dateLabel.Text = notification.Date.ToString();
        }
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            Navigation.ShowPopup(new DeleteNotificationPopup(_notification));
        }
    }
}