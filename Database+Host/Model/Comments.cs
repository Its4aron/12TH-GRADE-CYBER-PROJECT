
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comments : BaseEntity
    {
        private Person creator;
        private string comment;
        private Location loc;
        private DateTime cdate;

        public DateTime Cdate { get => cdate; set => cdate = value; }
        public Person Creator{ get => creator; set => creator = value; }
        public string Comment { get => comment; set => comment = value; }
        public Location Loc { get => loc; set => loc = value; }
    }
}
