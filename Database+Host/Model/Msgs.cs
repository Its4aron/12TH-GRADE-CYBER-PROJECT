using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Msgs : BaseEntity
    {
        private string txt;
        private Person sender;
        private DateTime txtdate;
        private int groupid;

        public string Txt
        {
            get
            {
                return Txt;
            }
            set
            {
                Txt = value;
            }

        }
        public Person Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }
        public DateTime TxtDate
        {
            get
            {
                return TxtDate;
            }
            set
            {
                TxtDate = value;
            }

        }
        public int GroupID
        {
            get
            {
                return GroupID;
            }
            set
            {
                GroupID = value;
            }
        }
    }
}
