using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Library.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OtherPage : ContentPage
    {
        public OtherPage()
        {
            InitializeComponent();

            if (LoadFlats() == true)
            {
                flatCollectionViewStackLayout.IsVisible = true;
                flatCollectionView.ItemsSource = App.Flats;
            }

        }

        private bool LoadFlats()
        {
            bool check = false;
            int FlatsInfo = 0;
            foreach (var flat in App.Flats)
            {
                FlatsInfo += 1;
            }
            if (FlatsInfo != 0)
            {
                check = true;
            }
            else
            {
                flatsLabel.Text = "Нет квартир";
            }
            return check;
        }

        private void AddFlatButton_Clicked(object sender, EventArgs e)
        {
            addFlatStackLayout.IsVisible = true;
        }

        private void AddWardrobeButton_Clicked(object sender, EventArgs e)
        {

        }

        private void flatCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void confirmFlatButton_Clicked(object sender, EventArgs e)
        {
            string name = nameFlatEntry.Text;
            var newFlat = new Flat { Name = name };
            await App.FlatDatabase.SaveFlatAsync(newFlat);


            App.Current.MainPage = new ShellPage();

            await Shell.Current.GoToAsync("///other");
        }
    }
}