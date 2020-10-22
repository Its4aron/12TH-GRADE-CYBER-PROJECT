using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkateApp.ServiceReference1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkateApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        Service1Client client = new Service1Client();
        public LoginPage()
        {
            
            InitializeComponent();
            client.LogInCompleted += Client_LogInCompleted;
        }
        public void Client_LogInCompleted(object sender, LogInCompletedEventArgs e)
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
                        Person p = e.Result;
                        if (p == null)
                        {
                            await DisplayAlert("Login Failed", "Login in error", "Exit");
                        }
                        else
                        {
                            App.PersonApp = p;
                            Navigation.InsertPageBefore(new TabPage(), this);
                            await Navigation.PopAsync();
                        }

                    }
                }
                    );
        }
        private void log_in(object sender, EventArgs e)
        {
            client.LogInAsync(u1.Text, p1.Text);
        }
        private async void go_to_reg(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new RegPage(), this);
            await Navigation.PopAsync();

        }
    }
}