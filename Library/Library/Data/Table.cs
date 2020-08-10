using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Library.Data
{
    public class Table
    {
        readonly SQLiteAsyncConnection database;
        public Table(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<BookTable>().Wait();
        }
        public Task<List<BookTable>> GetBooksAsync()
        {
            return database.Table<BookTable>().ToListAsync();
        }

        public Task<int> SaveBookAsync(BookTable book)
        {
            return database.InsertAsync(book);
        }

        public Task<BookTable> GetBookAsync(int id)
        {
            return database.GetAsync<BookTable>(id);
        }

        public Task<int> DeleteBookAsync(int id)
        {
            return database.DeleteAsync<BookTable>(id);
        }

        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<BookTable>();
        }

        public Task<int> UpdateAsync(BookTable book)
        {
            return database.UpdateAsync(book);
        }
    }
}
