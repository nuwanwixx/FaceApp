using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceIT2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();

        UserLogin user = new UserLogin();
        public SignInPage()
        {
            InitializeComponent();
            
        }


       async void Button_Login(object sender, EventArgs e)
        {
            var email = EmailEntry.Text;
            var password = PasswordEntry.Text;

            if (email.Contains("@") & email.Contains(".com"))
            {
                email = user.Email;
                password = user.Passsword;

                var content = JsonConvert.SerializeObject(user);
                await _client.PostAsync(Url, new StringContent(content));
                await Navigation.PushAsync(new TabPage());
            }

            else {
                ErrorLabel.Text = "Email is not valid";
            }
        }


        async private void Button_ForgetPassword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ForgetPasswordPage());
        }


    }
}