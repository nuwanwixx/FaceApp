using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceIT2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FaceSearchPage : ContentPage
    {
        public FaceSearchPage()
        {
            InitializeComponent();
        }


        private async void Button_UploadPhoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No camera", ":(No camera available.", "ok");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                }
                );

            if (file == null)
                return;

            PathLabel.Text = file.AlbumPath;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var Stream = file.GetStream();
                file.Dispose();
                return Stream;
            });
        }





        private async void Button_Galary(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("oops", "Gallery is not supported!", "ok");
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();

            if (file == null)
                return;

            PathLabel.Text = "Photo Path" + file.Path;

            MainImage.Source = ImageSource.FromStream(() =>
            {
                var Stream = file.GetStream();
                file.Dispose();
                return Stream;
            });

        }




        private void Button_Picture(object sender, EventArgs e)
        {

        }

         private void Button_Next(object sender, EventArgs e)
        {
            
        }


    }
}