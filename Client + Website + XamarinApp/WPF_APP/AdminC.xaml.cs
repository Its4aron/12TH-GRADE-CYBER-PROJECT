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
    /// Interaction logic for AdminC.xaml
    /// </summary>
    public partial class AdminC : Page
    {
        Service1Client client = new Service1Client();
        Person p;
        public AdminC(Person pa)
        {
          
            InitializeComponent();
            List.ItemsSource = client.SelectAllC();
            p = pa;
        }

        //public AdminC(Person c) : this()
        //{

            
           
        //    List.ItemsSource = client.SelectCbyP(c);

        

        private void locp(object sender, RoutedEventArgs e)
        {
            //Loc by com
        }

        private void gotolocation(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminL(p));
        }

        private void BackToUser(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate (new Admin(p));
        }

        
        private void gotosearch(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminCFilter(p));
        }

        private void Button_Clickl(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminCMyCom(p));
        }

        private void delete_comment(object sender, RoutedEventArgs e)
        {
            client.DeleteC(List.SelectedItem as Comments);

        }
    }
}

