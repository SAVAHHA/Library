using System;
using System.Collections.Generic;
using System.Text;
using Library.Model;

namespace Library.Data
{
    public static class BookData
    {
        public static IList<Book> Books { get; set; }
        static BookData()
        {
            //Books = new List<Book>();
            var Books = App.Database.GetBooksAsync().Result;
        }
    }
}
