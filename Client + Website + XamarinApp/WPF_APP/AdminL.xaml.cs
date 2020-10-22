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
    /// Interaction logic for AdminL.xaml
    /// </summary>
    public partial class AdminL : Page
    {
        Service1Client client = new Service1Client();
        Person p_a;
        public AdminL(Person pa)
        { 
            InitializeComponent();
            List.ItemsSource = client.SelectAllL();
            p_a = pa;

        }
        //string u;
        //public AdminL(Person l) : this()
        //{
            
        //     u = l.Username;
        //     Usernames.Text = u;
        //     LocationList lp = new LocationList();
        //     lp = client.Lby_Person(l);
        //     List.ItemsSource =lp;

        //}
        private void gotousers(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Admin(p_a));
        }

        private void backtoc(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminC(p_a));
        }

        private void locp(object sender, RoutedEventArgs e)
        {
            client.DeleteL(List.SelectedItem as Location);
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void loc_filter(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminLFilter(p_a));
        }

        private void map_view(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new locationview(p_a));
        }
    }
}
