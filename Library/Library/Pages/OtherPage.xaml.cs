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

            if (LoadWardrobes() == true)
            {
                wardrobeCollectionViewStackLayout.IsVisible = true;
                wardrobeCollectionView.ItemsSource = App.Wardrobes;
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

        private bool LoadWardrobes()
        {
            bool check = false;
            if (App.Wardrobes != null)
            {
                check = true;
            }
            else
            {
                wardrobesLabel.Text = "Нет шкафов";
            }
            return check;
        }

        private void AddFlatButton_Clicked(object sender, EventArgs e)
        {
            addFlatStackLayout.IsVisible = true;
        }

        private void AddWardrobeButton_Clicked(object sender, EventArgs e)
        {
            addWardrobeStackLayout.IsVisible = true;
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

        private async void confirmWardrobeButton_Clicked(object sender, EventArgs e)
        {
            string name = nameWardrobeEntry.Text;
            string flatName = flatWardrobeEntry.Text;
            int flatID = 0;
            foreach (var flat in App.Flats)
            {
                if (flat.Name == flatName)
                {
                    flatID = flat.ID;
                }
            }
            
            var newWardrobe = new Wardrobe { Name = name, ID_Flat = flatID };
            await App.WardrobeDatabase.SaveWardrobeAsync(newWardrobe);


            App.Current.MainPage = new ShellPage();

            await Shell.Current.GoToAsync("///other");
        }

        private void hideWardrobeButton_Clicked(object sender, EventArgs e)
        {
            addWardrobeStackLayout.IsVisible = false;
        }

        private void hideFlatButton_Clicked(object sender, EventArgs e)
        {
            addFlatStackLayout.IsVisible = false;
        }

        private void wardrobeCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}