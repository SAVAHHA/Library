using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;
using SQLite;
using System.Threading.Tasks;

namespace Library.Data
{
    public class WardrobeTable
    {
        readonly SQLiteAsyncConnection database;
        public WardrobeTable(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Wardrobe>().Wait();
        }
        public Task<List<Wardrobe>> GetWardrobesAsync()
        {
            return database.Table<Wardrobe>().ToListAsync();
        }

        public Task<int> SaveWardrobeAsync(Wardrobe wardrobe)
        {
            return database.InsertAsync(wardrobe);
        }

        public Task<Wardrobe> GetWardrobeAsync(int id)
        {
            return database.GetAsync<Wardrobe>(id);
        }

        public Task<int> DeleteWardrobeAsync(int id)
        {
            return database.DeleteAsync<Wardrobe>(id);
        }

        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<Wardrobe>();
        }

        public Task<int> UpdateAsync(Wardrobe wardrobe)
        {
            return database.UpdateAsync(wardrobe);
        }
    }
}
