using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkateApp.ServiceReference1;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkateApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   

    public partial class UpLocPage : ContentPage
    {
        Service1Client client = new Service1Client();
        SkateApp.ServiceReference1.Location loc;
        public UpLocPage()
        {
            InitializeComponent();
            client.all_l_typesAsync();
            client.all_l_typesCompleted += Client_all_l_typesCompleted;
            client.Create_LocationCompleted += Client_Create_LocationCompleted;
            loc = new SkateApp.ServiceReference1.Location();
            spot.BindingContext = loc;
        }

        private void Client_Create_LocationCompleted(object sender, Create_LocationCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(
               async () =>
               {
                   if (e.Error != null)
                   {
                       await DisplayAlert("An Error", e.Error.ToString(), "Exit");
                   }
                   else if (e.Cancelled == true)
                   {
                       await DisplayAlert("Event Cancelled", "Cancelled", "Exit");
                   }
                   else
                   {
                       int check = e.Result;
                       if (check == null)
                       {
                           await DisplayAlert("Failed", "Unable to upload location", "Exit");
                       }
                       else
                       {
                           await DisplayAlert("Succsess!", "Location was succsessfuly uploaded", "Exit");
                       }

                   }
               }
                   );
        }

        private void Client_all_l_typesCompleted(object sender, all_l_typesCompletedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(
                 async () =>
                 {
                     if (e.Error != null)
                     {
                         await DisplayAlert("An Error", e.Error.ToString(), "Exit");
                     }
                     else if (e.Cancelled == true)
                     {
                         await DisplayAlert("Event Cancelled", "Cancelled", "Exit");
                     }
                     else
                     {
                         LTypeList locl = e.Result;
                         if (locl == null)
                         {
                             await DisplayAlert("Failed to retreive list", "Unable to get list", "Exit");
                         }
                         else
                         {
                             locbox.ItemsSource = locl;
                         }

                     }
                 }
                     );
        }

        private async void up_spot(object sender, EventArgs e)
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            loc.Altitude = Convert.ToDouble(location.Latitude);
            loc.Longitude = Convert.ToDouble(location.Longitude);
            client.Create_LocationAsync(loc);


        }
    }
}