using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceIT2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private async void FaceSearch_Btn(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new FaceSearchPage());
        }

        private async void LocationSearch_Btn(object sender, EventArgs e)
        {
          await Navigation.PushAsync(new LocationSearchPage());
        }

        private async void NameSearch_Btn(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new NameSearchPage());
        }

        /*private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            myList.ItemsSource = GetContacts(e.NewTextValue);
        } */
    }
}