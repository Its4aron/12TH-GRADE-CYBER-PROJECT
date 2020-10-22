using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]

    public class MsgsList:List<Msgs>
    {
        public MsgsList()
        {

        }

        public MsgsList(IEnumerable<Msgs> list) : base(list)
        {
        }

        public MsgsList(IEnumerable<BaseEntity> list) : base(list.Cast<Msgs>().ToList())
        {
        }
    }
}
