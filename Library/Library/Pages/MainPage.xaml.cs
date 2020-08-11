using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private double lastScrollPoint = 0;
        private bool translating = false;
        private bool isVisible = true;
        public static List<Book> _books
        {
            get
            {
                return App.Books;
            }
        }
        
        public MainPage()
        {
            InitializeComponent();
            mainCollectionView.ItemsSource = _books;
            search.ItemsSource = _books;
            search.Books = _books;
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bookId = (e.CurrentSelection.FirstOrDefault() as Book).Name;
            await Shell.Current.GoToAsync("bookdetailpage");
        }
        private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (translating)
                return;
            uint mills = 100;
            translating = true;
            if (e.ScrollY > lastScrollPoint)
            {
                // hide
                if (isVisible)
                {
                    await PanelGrid.TranslateTo(PanelGrid.TranslationX, PanelGrid.TranslationY + PanelGrid.HeightRequest, mills);
                    isVisible = false;
                }
            }
            else
            {
                // show
                if (!isVisible)
                {
                    await PanelGrid.TranslateTo(PanelGrid.TranslationX, PanelGrid.TranslationY - PanelGrid.HeightRequest, mills);
                    isVisible = true;
                }
            }
            lastScrollPoint = e.ScrollY;
            translating = false;
        }

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            addBookStackLayout.IsVisible = true;
        }

        private void FilterButton_Clicked(object sender, EventArgs e)
        {

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

        private void hideBookAddButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}