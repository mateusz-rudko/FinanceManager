using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inzynierka.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        public NotificationsPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var notificationsList = await App.NotoficationsDatabase.GetAllNotoficationsAsync();
            if (notificationsList != null)
                NotificationsList.ItemsSource = notificationsList;
        }
        async void NotificationItem_Tapped(object sender, EventArgs e)
        {
            Notifications notification = NotificationsList.SelectedItem as Notifications;



            await Navigation.PushModalAsync(new NotificationRecordPage(notification));
        }
        private async void AddNewNotificationButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewNotificationPage()));
        }

        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}