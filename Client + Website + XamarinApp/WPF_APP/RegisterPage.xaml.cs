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
    public partial class RegisterPage : Page
    {
        Person p = new Person();
        Service1Client host;
        public RegisterPage()
        {
            host = new Service1Client();
            InitializeComponent();
            cities.ItemsSource = host.SelectAllTypes();
            this.DataContext = p;
            this.LB.Visibility = Visibility.Visible;
            this.back.Visibility = Visibility.Visible;
        }
        public RegisterPage(Person p):this()
        {
            this.p = p;
            PasswordBox.Password = p.Password;   
            STypeList l = host.SelectAllTypes();
            p.SType = l.Find(item => item.ID == p.SType.ID);
            this.DataContext = p;
            this.XX.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            p.Password = PasswordBox.Password;
            if (p.ID > 0)
            {
                host.UpdatePerson(p);
            }
            else
            {
                p.Trusted = false;
                p.Admin = false;
                p.ID = host.InsertPerson(p);
            }
            if (p.ID > 0)
            {    
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new LogInPage());
            }
            else { this.error.Text = "Error"; }
        }
            private void Button_Click_2(object sender, RoutedEventArgs e)
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                nav.Navigate(new LogInPage());
            }
        }
    }

