using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp6.ServiceReference1;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for CreateLocationPage.xaml
    /// </summary>
    public partial class CreateLocationPage : Page
    {
        Service1Client host = new Service1Client();
        Person p;
        double lat_final;
        double lng_final;
        Location loc = new Location();

      
        public CreateLocationPage(Person user,double lat,double lng)
        {
           
            InitializeComponent();
            p = user;
            Location_Types.ItemsSource = host.all_l_types();
            lat_final = lat;
            lng_final = lng;
           
         

        }

        private void Button_CreateLocation(object sender, RoutedEventArgs e)
        {
            string name = Location_Name.Text;
            string des = Description.Text;
            LType type = Location_Types.SelectedItem as LType;
            loc.Longitude = lat_final;
            loc.Altitude = lng_final;
            loc.Name = name;
            loc.Des = des;
            loc.Type = type;
            int id = host.Create_Location(loc);
            if (id != -1)
            {
                Console.WriteLine("it worked");
            }
            host.comment_creator(p, loc);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new MyCommentsPage(p));
        }
    }
}
