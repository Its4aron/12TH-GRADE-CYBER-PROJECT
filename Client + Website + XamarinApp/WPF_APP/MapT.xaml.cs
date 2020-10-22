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
using GMap;
using GMap.NET;
using GMap.NET.WindowsPresentation;
using WpfApp6.ServiceReference1;


namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MapT.xaml
    /// </summary>
    public partial class MapT : Page
    {
        private double AfterclickL;
        private double AfterClickLng;
        Service1Client host = new Service1Client();
        public MapT()
        {
            InitializeComponent();
            map.MapProvider = GMap.NET.MapProviders.GMapProviders.GoogleMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            PointLatLng p  = new PointLatLng(32.126888, 34.844381);
            map.Position = p;
            map.MinZoom = 2;
            map.MaxZoom = 17;
            map.Zoom = 50;  
            map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            map.CanDragMap = true;
            AllPins(map);
            map.DragButton = MouseButton.Left;
           map.MouseDoubleClick += GMap_GetLocation_Doubleclick; //לחיצת כפול על ידי עכבר במפה   
        }
        public double AfterclickL1 { get => AfterclickL; set => AfterclickL = value; }
        public double AfterClickLng1 { get => AfterClickLng; set => AfterClickLng = value; }
        public void AllPins(GMapControl map)
        {
            List<GMapMarker> markers = map.Markers.ToList();
            LocationList l = host.SelectAllL();
            foreach(Location location in l)
            {
                Map_pin  pin = new Map_pin(location);
                pin.Width = 20;
                pin.Height = 35;
                PointLatLng point = new PointLatLng(location.Altitude,location.Longitude);
                GMapMarker mark = new GMapMarker(point);
                mark.Shape = pin;
                map.Markers.Add(mark);
            }
        }
        public void GMap_GetLocation_Doubleclick(Object sender, MouseEventArgs e) //   פעולת המחזירה מיקום על ידי Longtitude and Latidtiude  
        {
            Point l = e.GetPosition(map);
            Console.WriteLine(l.X + " " + l.Y);
            System.Diagnostics.Debug.WriteLine("Location:" + l);
            double lat = map.FromLocalToLatLng((int)l.X, (int)l.Y).Lat;
            double lng = map.FromLocalToLatLng((int)l.X, (int)l.Y).Lng;
            Console.WriteLine("lat=" + lat + "  lng=" + lng);
            AfterclickL1 = lng;
            AfterClickLng1 = lat;
        }
    }

}
