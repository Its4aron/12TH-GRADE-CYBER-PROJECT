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
    /// <summary>
    /// Interaction logic for Map_pin.xaml
    /// </summary>
    public partial class Map_pin : UserControl
    {
        public Map_pin()
        {
            InitializeComponent();
        }

        public Map_pin(Location loc)
        {
            InitializeComponent();
            string s = "  ";
            txt.Text = loc.Name+s+loc.Des;
            txt.Foreground = Brushes.White;
            this.MouseEnter += new MouseEventHandler(Show);
            this.MouseLeave += new MouseEventHandler(Leave);
        }
        public void Show(object sender,MouseEventArgs e)
        {
            popup.IsOpen = true;
        }
        public void Leave(object sender, MouseEventArgs e)
        {
            popup.IsOpen = false;
        }
    }
     
}
