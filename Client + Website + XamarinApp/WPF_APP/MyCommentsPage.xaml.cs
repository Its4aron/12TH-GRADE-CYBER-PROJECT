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
    /// Interaction logic for MyCommentsPage.xaml
    /// </summary>
    public partial class MyCommentsPage : Page
    {
        public MyCommentsPage(Person p)
        {
            InitializeComponent();
            Service1Client host = new Service1Client();
            List.ItemsSource = host.SelectCbyP(p);
        }
        public MyCommentsPage()
        {
            InitializeComponent();
            Service1Client host = new Service1Client();
            List.ItemsSource = host.SelectAllC();
        }
     
            
    }
}
