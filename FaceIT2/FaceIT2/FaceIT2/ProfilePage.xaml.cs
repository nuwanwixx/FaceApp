using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FaceIT2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string MyProperty { get; set; }
    }
    public partial class ProfilePage : ContentPage
    {
        private const string Url = "https://jsonplaceholder.typicode.com/posts";
        private HttpClient _client = new HttpClient();
        private ObservableCollection<Post> _post;

       /* protected override async void OnAppearing()
        {
            var content = await _client.GetStringAsync(Url);
            var posts = JsonConvert.DeserializeObject<List<Post>>(content);

            _post = new ObservableCollection<Post>(posts);
            postsListView.ItemsSource = _post;

            base.OnAppearing();

        }*/
        /// <summary>
        /// 
        /// </summary>
        public ProfilePage()
        {
            InitializeComponent();
            profile.Source = ImageSource.FromResource("FaceIT2.Images.beardface.png");
            myList.ItemsSource = GetContacts();           
        }

        private void myList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            myList.SelectedItem = null;
            //var contact = e.SelectedItem as Contact;
            //DisplayAlert("Selected", contact.Name, "OK");
        }

        IEnumerable<Contact> GetContacts(string searchText =null)
        {
            var contacts = new List<Contact>
            {
                new Contact {Name ="Description", Status ="Tech Geek. Software Engineer ", ImageUrl = "http://lorempixel.com/100/100/people/3/" },
                new Contact { Name = "Works At", Status = "CodeGen Pvt.Ltd", ImageUrl = "http://lorempixel.com/100/100/people/4/" },
                new Contact {Name = "Education", Status = "University of Moratuwa, Faculty of Information Technology", ImageUrl="http://lorempixel.com/100/100/people/5/" },
                new Contact {Name ="Hobby", Status ="Playing Chess", ImageUrl = "http://lorempixel.com/100/100/people/1/" },
                new Contact { Name = "Location", Status = "Moratuwa, Sri Lanka", ImageUrl = "http://lorempixel.com/100/100/people/2/" },
                
            };
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return contacts;
            }
            else
            {
                return contacts.Where(c => c.Name.StartsWith(searchText));
            }
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Edit", contact.Name, "OK");
        }

        private void ToolBar_Btn1(object sender, EventArgs e)
        {

        }

        private void ToolBar_Btn2(object sender, EventArgs e)
        {

        }
    }
}