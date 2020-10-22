using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SkateApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : Xamarin.Forms.TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Xamarin.Forms.Color.White;
            this.BarTextColor = Xamarin.Forms.Color.Black;
            Children.Add(new LocPage() { IconImageSource = "locImg.png", Title = "Location Page" });
            Children.Add(new UpLocPage() { IconImageSource = "up.png", Title = "Upload Location" });
            
        }
    }
}