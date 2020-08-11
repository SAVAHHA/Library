using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Library.Model;

namespace Library.Data
{
    public class BookTable
    {
        readonly SQLiteAsyncConnection database;
        public BookTable(string databasePath)
        {
            database = new SQLiteAsyncConnection(databasePath);
            database.CreateTableAsync<Book>().Wait();
        }
        public Task<List<Book>> GetBooksAsync()
        {
            return database.Table<Book>().ToListAsync();
        }

        public Task<int> SaveBookAsync(Book book)
        {
            return database.InsertAsync(book);
        }

        public Task<Book> GetBookAsync(int id)
        {
            return database.GetAsync<Book>(id);
        }

        public Task<int> DeleteBookAsync(int id)
        {
            return database.DeleteAsync<Book>(id);
        }

        public Task<int> DeleteAll()
        {
            return database.DeleteAllAsync<Book>();
        }

        public Task<int> UpdateAsync(Book book)
        {
            return database.UpdateAsync(book);
        }
    }
}
