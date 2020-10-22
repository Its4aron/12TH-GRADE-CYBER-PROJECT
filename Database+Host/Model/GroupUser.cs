using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupUser : BaseEntity

    {
        private Person user;
        private Group group;

        public Person User { get => user; set => user = value; }
        public Group Group { get => group; set => group = value; }
    }
}
