using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkateApp.ServiceReference1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace SkateApp
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocPage : ContentPage
    {
        LocationList l;
        Service1Client client = new Service1Client();
        public LocPage()
        {
            InitializeComponent();
            client.SelectAllLAsync();
            l = new LocationList();
            client.SelectAllLCompleted += Client_SelectAllLCompleted;
        }
        public void Client_SelectAllLCompleted(object sender, SelectAllLCompletedEventArgs e)
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
                       LocationList l = e.Result as LocationList ;
                       if (l == null)
                       {
                           await DisplayAlert("failed to get list", "List is null", "Exit");
                       }
                       else
                       {
                           lc.ItemsSource = l;
                          
                       }

                   }
               }
                   );
        }
        private async void NavigateItem(object sender, SelectedItemChangedEventArgs e)
        {
            ServiceReference1.Location loc = lc.SelectedItem as ServiceReference1.Location;
            Xamarin.Essentials.Location l = new Xamarin.Essentials.Location(loc.Altitude,loc.Longitude) ;
            MapLaunchOptions options = new MapLaunchOptions() { NavigationMode = NavigationMode.Driving };
            await Map.OpenAsync(l, options);
        }
    }
}
