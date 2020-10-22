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
using WpfApp6;
using WpfApp6.ServiceReference1;


namespace WpfApp6
{
  
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Service1Client host = new Service1Client();
            Person p = host.LogIn(Username.Text, Password.Password);
            if (p == null)
            {
                this.error.Text = "Error";
                error.Visibility = Visibility.Visible;
            }
            else
            {
                if (p.Admin)
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new Admin(p));
                }
                else
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new locationview(p));
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new RegisterPage());
        }
        private void hand(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new RegisterPage());
            }
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Service1Client host = new Service1Client();
                Person p = host.LogIn(Username.Text, Password.Password);
                if (p == null)
                {
                    this.error.Text = "Error";
                    error.Visibility = Visibility.Visible;
                }
                else
                {
                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new locationview(p));

                }
            }
        }
    }
}
