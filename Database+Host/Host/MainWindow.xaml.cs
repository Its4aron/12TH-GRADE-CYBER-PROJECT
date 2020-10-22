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
using System.ServiceModel;
using ServiceLibary;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //ServiceHost service = new ServiceHost(typeof(ServiceLibary.Service1));
            //service.Open();

            InitializeComponent();

            ServiceHost host = new ServiceHost(typeof(ServiceLibary.Service1));
            host.Open();
            

        //    PersonDB db = new PersonDB();
        //Person p = db.LogIn("Sharon", "HolyTeeth");
        //    Person p1 = new Person
        //    {
        //        Username = "josh",
        //        Password = "nirs",
        //        Admin = false,
        //        Email = "d",
        //        Trusted = false,
        //        SType = new STypes() { ID = 1 },
                

                

        //    };
        //    db.Insert(p1);
        //    int x=   db.SaveChanges();
        //    int i = 9;
        }
    }
}
 