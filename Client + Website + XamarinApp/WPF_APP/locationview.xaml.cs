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
    /// Interaction logic for locationview.xaml
    /// </summary>
    public partial class locationview : Page
    {
        Service1Client host = new Service1Client();
        static Page currentpage;
        private Person p;
        public locationview(Person User)
        {
            InitializeComponent();
            p = User;
            currentpage = new MapT();
            frame.Navigate(currentpage);
            if (p.Admin)
            {
                this.b1.Visibility = Visibility.Collapsed;
                this.b2.Visibility = Visibility.Collapsed;
                this.b3.Visibility = Visibility.Visible;
                this.b4.Visibility = Visibility.Visible;
                this.b7.Visibility = Visibility.Collapsed;
            }
        }
        private void Button_ChangeView(object sender, RoutedEventArgs e)
        {
            if (currentpage.Name == "Map_Page")
            {
                currentpage = new Locationlistpage();
            }
            else
            {
                currentpage = new MapT();
            }
            frame.Navigate(currentpage);
        }
        private void Button_InsertLocation(object sender, RoutedEventArgs e)
        {  
            if (currentpage.Name == "Map_Page")
            {
                MapT map = currentpage as MapT;
                double lat = map.AfterclickL1;
                double lng = map.AfterClickLng1;
                Console.WriteLine("lOCATION THAT WILL BE SENT IS: "+lat+" "+lng);
                currentpage = new CreateLocationPage(p,lat,lng);
            }
            else
            {
                currentpage = new MapT();
            }
            frame.Navigate(currentpage);
        }
        private void Button_MyCom(object sender, RoutedEventArgs e)
        {
                if (currentpage.Name == "Map_Page" || currentpage.Name == "Location_listP")
                {
                    currentpage = new MyCommentsPage(p);
                }
                else
                {
                    currentpage = new MapT();
                }
                frame.Navigate(currentpage);   
        }
        private void Back_admin(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminL(p));
        }
        private void logout(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new LogInPage());
        }
    }
    }


          