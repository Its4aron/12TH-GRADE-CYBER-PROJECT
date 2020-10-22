using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]

    public class LTypeList:List<LType>
    {
        public LTypeList()
        {

        }

        public LTypeList(IEnumerable<LType> list) : base(list)
        {
        }

        public LTypeList(IEnumerable<BaseEntity> list) : base(list.Cast<LType>().ToList())
        {
        }
    }
}
