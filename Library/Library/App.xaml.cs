using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Library.Data;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Library.Model;

namespace Library
{
    public partial class App : Application
    {
        public const string BOOK_DATABASE_NAME = "booktable.db";
        public const string FLAT_DATABASE_NAME = "flattable.db";
        public const string WARDROBE_DATABASE_NAME = "wardrobetable.db";

        static BookTable bookDatabase;
        static FlatTable flatDatabase;
        static WardrobeTable wardrobeDatabase;

        public static BookTable BookDatabase
        {
            get
            {
                if (bookDatabase == null)
                {
                    bookDatabase = new BookTable(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), BOOK_DATABASE_NAME));
                }
                return bookDatabase;
            }
        }

        public static FlatTable FlatDatabase
        {
            get
            {
                if (flatDatabase == null)
                {
                    flatDatabase = new FlatTable(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FLAT_DATABASE_NAME));
                }
                return flatDatabase;
            }
        }

        public static WardrobeTable WardrobeDatabase
        {
            get
            {
                if (wardrobeDatabase == null)
                {
                    wardrobeDatabase = new WardrobeTable(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), WARDROBE_DATABASE_NAME));
                }
                return wardrobeDatabase;
            }
        }

        public static List<Book> Books
        {
            get
            {
                List<Book> books = new List<Book>();
                if (App.BookDatabase.GetBooksAsync().Result != null)
                {
                    books = App.BookDatabase.GetBooksAsync().Result;
                }
                return books;
            }
        }

        public static List<Flat> Flats
        {
            get
            {
                List<Flat> flats = new List<Flat>();
                if (App.FlatDatabase.GetFlatsAsync().Result != null)
                {
                    flats = App.FlatDatabase.GetFlatsAsync().Result;
                }
                return flats;
            }
        }

        public static List<Wardrobe> Wardrobes
        {
            get
            {
                List<Wardrobe> wardrobes = new List<Wardrobe>();
                if (App.WardrobeDatabase.GetWardrobesAsync().Result != null)
                {
                    wardrobes = App.WardrobeDatabase.GetWardrobesAsync().Result;
                }
                return wardrobes;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new ShellPage();
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
