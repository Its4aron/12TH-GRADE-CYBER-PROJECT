using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]

    public class STypeList:List<STypes>
    {
        public STypeList()
        {

        }

        public STypeList(IEnumerable<STypes> list) : base(list)
        {
        }

        public STypeList(IEnumerable<BaseEntity> list) : base(list.Cast<STypes>().ToList())
        {
        }
    }
}
