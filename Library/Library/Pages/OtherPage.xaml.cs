using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }

        private void AddWardrobeButton_Clicked(object sender, EventArgs e)
        {

        }

        private void flatCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}