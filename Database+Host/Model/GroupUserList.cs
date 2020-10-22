using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]

    public class GroupUserList:List<GroupUser>
    {
        public GroupUserList()
        {

        }

        public GroupUserList(IEnumerable<GroupUser> list) : base(list)
        {
        }

        public GroupUserList(IEnumerable<BaseEntity> list) : base(list.Cast<GroupUser>().ToList())
        {
        }
    }
}
