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
    public partial class Admin : Page
    {
        Service1Client host = new Service1Client();
        Person pa;
        public Admin(Person p)
        {
            Service1Client client = new Service1Client();
            InitializeComponent();
            List.ItemsSource = client.SelectAllPersons();
            pa = p;
        }
        private void mupdate(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new RegisterPage(List.SelectedItem as Person));
        }
        private void udelte(object sender, RoutedEventArgs e)
        {
         
            host.Delete(List.SelectedItem as Person);
            delete.Text = "Deleted worked";
        }
        private void comuser(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminC(List.SelectedItem as Person));

        }
        private void Button_Clickl(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminL(pa));
        }
        private void Button_Clickc(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminC(pa));
        }
        private void luser(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminL(List.SelectedItem as Person));
        }
        private void log_out(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate (new LogInPage());
        }
    }
}
