using Inzynierka.Models;
using Plugin.LocalNotification;
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
    public partial class NewNotificationPage : ContentPage
    {
       
        public NewNotificationPage()
        {
            InitializeComponent();
        }
        private async void ExitButtonClicked(object sender, EventArgs e)
        {
            int numModals = Application.Current.MainPage.Navigation.ModalStack.Count;
            for (int currModal = 0; currModal < numModals; currModal++)
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }
        private async void AddButtonClicked(object sender, EventArgs e)
        {
            

            if (notificationName.Text != null && notificationDescription.Text != null &&  notificationDataPicker.Date != null)
            {
                await App.NotoficationsDatabase.AddNewNotification(new Notifications
                {
                    Name = notificationName.Text,
                    Description = notificationDescription.Text,
                    Date = notificationDataPicker.Date + notificationTimePicker.Time,
                });
                var notification = new NotificationRequest
                {
                    BadgeNumber = 1,
                    Description = notificationDescription.Text,
                    Title = notificationName.Text,
                    NotifyTime = notificationDataPicker.Date + notificationTimePicker.Time
                   
                };
                
                NotificationCenter.Current.Show(notification);
                await Navigation.PopModalAsync();
            }
        }
    }
}