using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Library.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private double lastScrollPoint = 0;
        private bool translating = false;
        private bool isVisible = true;
        public static List<BookTable> _books
        {
            get
            {
                return App.Books;
            }
        }
        
        public MainPage()
        {
            InitializeComponent();
            //D();
            mainCollectionView.ItemsSource = _books;
            search.ItemsSource = _books;
            search.Books = _books;
           // BookData.Books.Add(new Book() { Name = "Hello", Author = "Andrew" });
        }

        private async void D()
        {
            //var newBook = new BookTable { Author = "TTT", Name = "fff" };
            //await App.Database.SaveBookAsync(newBook);
            await DisplayAlert(App.Books[2].Author, App.Database.GetBooksAsync().Result.Count().ToString(), "OK");
        }

        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string bookId = (e.CurrentSelection.FirstOrDefault() as BookTable).Name;
            
            //await Shell.Current.GoToAsync($"bookdetailpage?bookid={bookId}");
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

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("addbookpage");
        }
    }
}