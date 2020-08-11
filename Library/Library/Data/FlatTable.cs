using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using SQLite;
using System.Threading.Tasks;

namespace Library.Data
{
    public class FlatTable
    {
        readonly SQLiteAsyncConnection database;
        public FlatTable(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Flat>().Wait();
        }
        public Task<List<Flat>> GetFlatsAsync()
        {
            return database.Table<Flat>().ToListAsync();
        }

        public Task<int> SaveFlatAsync(Flat flat)
        {
            return database.InsertAsync(flat);
        }

        public Task<Flat> GetFlatAsync(int id)
        {
            return database.GetAsync<Flat>(id);
        }

        public Task<int> DeleteFlatAsync(int id)
        {
            return database.DeleteAsync<Flat>(id);
        }

        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<Flat>();
        }

        public Task<int> UpdateAsync(Flat flat)
        {
            return database.UpdateAsync(flat);
        }
    }
}
