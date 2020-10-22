using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkateApp.ServiceReference1;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SkateApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegPage : ContentPage, INotifyPropertyChanged
    {
        Service1Client client = new Service1Client();
        Person p;
      
        public RegPage()
        {
            InitializeComponent();
            client.SelectAllTypesAsync();
            client.InsertPersonCompleted += Client_InsertPersonCompleted;
            client.SelectAllTypesCompleted += Client_SelectAllTypesCompleted;
            p = new Person();
            g.BindingContext = P;
        }
        public Person P { get => p; set { p = value; OnPropertyChanged(); } }
        public void Client_InsertPersonCompleted(object sender, InsertPersonCompletedEventArgs e)
        {
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
                           P.ID = e.Result;
                           if (P == null)
                           {
                               await DisplayAlert("Register failed", e.Error.ToString(), "Exit"); ;
                           }
                           else
                           {
                               if (P.ID > 0)
                               {
                                   Navigation.InsertPageBefore(new LoginPage(), this);
                                   await Navigation.PopAsync();

                               }
                               else await DisplayAlert("An Error", "Failed to create this account", "Exit");
                           }

                       }
                   }
                       );
            }
        }
       
        private void Client_SelectAllTypesCompleted(object sender, SelectAllTypesCompletedEventArgs e)
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
                       STypeList p = e.Result;
                       if (p == null)
                       {
                           await DisplayAlert("Retrival of list failed", "Enable to collect list", "Exit");
                       }
                       else
                       {
                           box.ItemsSource = p;
                       }
                   }
               }
                   );
        }
        private async void reg(object sender, EventArgs e)
        {  
            P.Admin = false;
            P.Trusted = false;
            client.InsertPersonAsync(P);   
        }
        private async void back_r(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new LoginPage(), this);
             await Navigation.PopAsync();
        }
    }
}