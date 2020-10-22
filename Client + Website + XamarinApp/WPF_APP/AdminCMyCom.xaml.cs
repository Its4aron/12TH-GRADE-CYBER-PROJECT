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
    public partial class AdminCMyCom:Page
    {
        static Page currentpage;
        Person p = new Person();
        Service1Client host = new Service1Client();
        public AdminCMyCom(Person pa)
        {

            InitializeComponent();
            p = pa;
            currentpage = new MyCommentsPage(p);
            frame.Navigate(currentpage);
           


        }

        private void BackToComments(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new AdminC(p));
        }

       
    }
}
