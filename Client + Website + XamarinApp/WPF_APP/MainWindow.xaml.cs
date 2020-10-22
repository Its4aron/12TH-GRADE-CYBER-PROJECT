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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame frame;
        public MainWindow()
        {
            InitializeComponent();
            frame = new Frame();
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            frame.Navigated += Frame_Navigated;
            Main.Children.Add(frame);
            frame.Navigate(new LogInPage());
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
            //    if (e.Content.GetType() == typeof (Admin))
            //    {this.Width= }
            //
        }
    }
}
