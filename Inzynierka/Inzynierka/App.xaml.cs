using Inzynierka.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Inzynierka
{
    public partial class App : Application
    {
        private static DataBaseConnection database;
        private static NotificationDataBaseConnection notoficationsDatabase;
        public static DataBaseConnection Database
        {
            get
            {
                if (database == null)
                {
                    database = new DataBaseConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"finance_db.db3"));
                }
                return database;
            }
        }
        public static NotificationDataBaseConnection NotoficationsDatabase
        {
            get 
            {
                if(notoficationsDatabase == null)
                {
                    notoficationsDatabase = new NotificationDataBaseConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notofications_db.db3"));
                }
                return notoficationsDatabase; 
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
