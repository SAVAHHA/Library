using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Library.Data;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "table.db";
        static Table database;
        public static Table Database
        {
            get
            {
                if (database == null)
                {
                    database = new Table(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public static List<BookTable> Books
        {
            get
            {
                List<BookTable> books = new List<BookTable>();
                if (App.Database.GetBooksAsync().Result != null)
                {
                    books = App.Database.GetBooksAsync().Result;
                }
                return books;
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
