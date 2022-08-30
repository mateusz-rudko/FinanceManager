using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inzynierka.Models;
using SQLite;

namespace Inzynierka.Services
{
    public class NotificationDataBaseConnection
    { 
        private readonly SQLiteAsyncConnection _notoficationsDatabase;
        public NotificationDataBaseConnection(string dbPath)
        {
            _notoficationsDatabase = new SQLiteAsyncConnection(dbPath);
            _notoficationsDatabase.CreateTableAsync<Notifications>();
        }
        public Task<List<Notifications>> GetAllNotoficationsAsync()
        {
            return _notoficationsDatabase.Table<Notifications>().ToListAsync();
        }
        public Task<int> AddNewNotification(Notifications notification)
        {
            return _notoficationsDatabase.InsertAsync(notification);
        }
        public Task<int> RemoveNotification(Notifications notification)
        {
            return _notoficationsDatabase.DeleteAsync(notification);
        }

    }
}
