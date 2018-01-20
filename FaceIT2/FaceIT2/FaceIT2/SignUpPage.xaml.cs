using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.ProjectOxford.Common.Contract;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using System.Linq;
using System.Threading;


namespace FaceIT2
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
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

            /*MainImage.Source = ImageSource.FromStream(() =>
            {
                var Stream = file.GetStream();
                file.Dispose();
                return Stream;
            }); */

            var c = ImageSource.FromStream(() => file.GetStream());
            StreamImageSource streamSource = (StreamImageSource)c;
            System.Threading.CancellationToken cancelT = System.Threading.CancellationToken.None;
            Task<Stream> task1 = streamSource.Stream(cancelT);
            Stream stream = task1.Result;

            Photo photo1 = new Photo();

            var img1 = await photo1.call(stream);
            photoLabel.Text = img1;

        }

        




        private void Button_Picture(object sender, EventArgs e)
        {
           
        }

       async private void Button_Next(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage2());
        }

       
    }
    public class Photo
    {
        private readonly IFaceServiceClient faceServiceClient = new FaceServiceClient("eda91d84d8d74e99b5afa36073cea990", "https://southeastasia.api.cognitive.microsoft.com/face/v1.0");
        String groupId = "001";

        public async Task<String> call(Stream s)
        {
            var faces = await faceServiceClient.DetectAsync(s);
            if (faces.Length == 0)
            {
                return "No face Detected";
            }
            if (faces.Length > 1)
            {
                return "To many Faces";
            }
            else
            {
                return "Face Detected Successfully";
            }
        }
    }
}