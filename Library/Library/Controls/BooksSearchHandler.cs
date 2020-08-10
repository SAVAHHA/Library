using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Xamarin.Forms;
using Library.Data;

namespace Library.Controls
{
    public class BooksSearchHandler: SearchHandler
    {
        public IList<BookTable> Books { get; set; }
        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                ItemsSource = Books
                    .Where(book => book.Name.ToLower().Contains(newValue.ToLower()) | book.Author.ToLower().Contains(newValue.ToLower()))
                    .ToList<BookTable>();

            }
        }

        //protected override async void OnItemSelected(object item)
        //{
        //    base.OnItemSelected(item);
        //    await Task.Delay(1000);

        //    ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;
        //    //await Shell.Current.GoToAsync($"{GetNavigationTarget()}?model={((Car)item).Model}");
        //    await Shell.Current.GoToAsync($"saledetails?carmodel={((Car)item).Model}");
        //}
    }
}
