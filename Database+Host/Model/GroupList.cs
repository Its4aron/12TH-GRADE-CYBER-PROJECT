using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]

    public class GroupList:List<Group>
    {
        public GroupList()
        {

        }

        public GroupList(IEnumerable<Group> list) : base(list)
        {
        }

        public GroupList(IEnumerable<BaseEntity> list) : base(list.Cast<Group>().ToList())
        {
        }
    }
}
