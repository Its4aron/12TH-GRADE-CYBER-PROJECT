using SkateApp.ServiceReference1;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkateApp
{
    public partial class App : Application
    {
        public static Person PersonApp;
        public App()
        {
            InitializeComponent();
           
             MainPage = new NavigationPage(new TabPage());
          
        }

        protected override void OnStart()
        {
            PersonApp = null;
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
