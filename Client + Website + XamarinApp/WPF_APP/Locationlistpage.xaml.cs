﻿using System;
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
    /// Interaction logic for Locationlistpage.xaml
    /// </summary>
    public partial class Locationlistpage : Page
    {
        Service1Client host = new Service1Client();
        public Locationlistpage()
        {
            InitializeComponent();
            List.ItemsSource = host.SelectAllL();
        }
        public Locationlistpage(Person p) : this()
        {
            List.ItemsSource = host.Lby_Person(p);
        }

        private void ComL(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
