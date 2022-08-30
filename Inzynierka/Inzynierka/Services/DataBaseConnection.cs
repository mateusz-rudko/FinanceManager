using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Inzynierka.Models;
using SQLite;


namespace Inzynierka.Services
{
    public class DataBaseConnection
    {
        private readonly SQLiteAsyncConnection _database;
        public DataBaseConnection(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Transaction>();
        }
        public Task<List<Transaction>> GetAllTransactionsAsync()
        {
            return _database.Table<Transaction>().ToListAsync();
        }
       
        public Task<int> AddNewTransaction(Transaction transaction)
        {
            return _database.InsertAsync(transaction);
        }
        public Task<int> RemoveTransaction(Transaction transaction)
        {
            return _database.DeleteAsync(transaction);
        }
        public Task<int> UpdateTransaction(Transaction transaction)
        {
            return _database.UpdateAsync(transaction);
        }
        
    }
}
