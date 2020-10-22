using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Picture : BaseEntity
    {
        private string pic;
        private Location loc;

        public string Pic
        {
            get
            {
                return Pic;
            }
            set
            {
                Pic = value;
            }
        }
        public Location Loc
        {
            get
            {
                return Loc;
            }
            set
            {
                Loc = value;
            }
        }
    }
}
