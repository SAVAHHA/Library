using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   // [QueryProperty("BookId", "bookid")]
    public partial class BookDetailPage : ContentPage
    {
        //public string BookId
        //{

        //    set
        //    {
        //         BindingContext = BookData.Books.FirstOrDefault(m => m.Name == Uri.UnescapeDataString(value));
        //    }
        //}

        public BookDetailPage()
        {
            InitializeComponent();
        }
    }
}