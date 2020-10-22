using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Location : BaseEntity
    {
        private double longitude;
        private double altitude;
        private LType type;
        private string des;
        private string name;
        private double lng;
        private double lat;
        private LType type1;
        private string desc;

        public Location()
        {        }
        public Location(double lng, double lat, LType type1, string desc, string name)
        {
            this.lng = lng;
            this.lat = lat;
            this.type1 = type1;
            this.desc = desc;
            this.name = name;
        }

        public double Longitude { get => longitude; set => longitude = value; }
        public double Altitude { get => altitude; set => altitude = value; }
        public LType Type{ get => type; set => type = value; }
        public string Des { get => des; set => des = value; }
        public string Name { get => name; set => name = value; }
       
    }
}
