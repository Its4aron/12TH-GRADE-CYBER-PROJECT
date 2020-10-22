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
    /// Interaction logic for ImageTest.xaml
    /// </summary>
    public partial class ImageTest : Page
    {
        string pic3;
        public string Pic3 { get => pic3; set => pic3 = value; }
        public ImageTest()
        {
            InitializeComponent();
            pic3 = "test.png";
            this.DataContext = this;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            //      dlg.DefaultExt = ".png";
            dlg.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
          //      this.comment.Pic = "pic" + this.comment.id + ".png";;


                byte[] imgArray = System.IO.File.ReadAllBytes(filename);

                Service1Client service = new Service1Client();
                service.SaveImage(imgArray, System.IO.Path.GetFileName(filename));




            }
        }


    }
}
