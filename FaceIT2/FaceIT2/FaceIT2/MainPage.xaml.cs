using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FaceIT2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            image1.Source = ImageSource.FromResource("FaceIT2.Images.background.jpg");
        }

        

       

        async void Button_SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }

        async void Button_SignIn(object sender, EventArgs e)
        {
           await Navigation.PushAsync(new SignInPage());
        }
    }
}
