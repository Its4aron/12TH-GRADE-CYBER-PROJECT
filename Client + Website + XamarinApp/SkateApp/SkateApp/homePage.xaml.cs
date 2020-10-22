using SkateApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkateApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class homePage : ContentPage
    {
        private Person personLoggedIn;

        public homePage()
        {
            InitializeComponent();
        }

        public homePage(Person personLoggedIn)
        {
            this.personLoggedIn = personLoggedIn;
        }
    }
}