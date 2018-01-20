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
    public partial class SignUpPage2 : ContentPage
    {
        public SignUpPage2()
        {
            InitializeComponent();
        }

        async private void Button_CreateAcount(object sender, EventArgs e)
        {

            var email = EmailEntry.Text;

            if (EmailEntry.Text != null)
            {

                if (email.Contains("@") & email.Contains(".com"))
                {
                    await Navigation.PushAsync(new ProfilePage());
                }


                else
                {
                    ErrorLabel.Text = "Email is not valid";
                    return;

                }
            }
            else
            {
                ErrorLabel.Text = "Please Enter Email";
            }

            await Navigation.PushAsync(new TabPage());

        }

        
    }
}