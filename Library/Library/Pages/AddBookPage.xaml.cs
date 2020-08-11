using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Library.Model;

namespace Library.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddBookPage : ContentPage
    {
        public AddBookPage()
        {
            InitializeComponent();
        }

        private async void confirmButton_Clicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string author = authorEntry.Text;
            var newBook = new Book { Author = author, Name = name };
            await App.BookDatabase.SaveBookAsync(newBook);


            App.Current.MainPage = new ShellPage();

            await Shell.Current.GoToAsync("///main");
        }
    }
}