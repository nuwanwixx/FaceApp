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
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
            NotificationList.ItemsSource = new List<Contact>
            {
                new Contact {Name="Supunmali Ahangama", Status="Lecturer at Faculty of IT UOM", ImageUrl="supunmali_ahangama.png"},
                new Contact {Name="Lochandaka Ranathunga", Status="Lecturer at Faculty of IT UOM", ImageUrl="lochandaka_ranathunga.png" },
            };
        }

        private void Notification_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NotificationList.SelectedItem = null;
        }
    }
}