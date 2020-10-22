using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Group : BaseEntity

    {
        private string groupname;
        private string pic;
        private DateTime groupdate;

        public string Groupname { get => groupname; set => groupname = value; }
        public string Pic { get => pic; set => pic = value; }
        public DateTime Groupdate { get => groupdate; set => groupdate = value; }
    }
}
