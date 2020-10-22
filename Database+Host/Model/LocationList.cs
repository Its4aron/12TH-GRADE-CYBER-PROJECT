using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
namespace Model
{
    [CollectionDataContract]

    public class LocationList:List<Location>
    {
        public LocationList()
        {

        }

        public LocationList(IEnumerable<Location> list) : base(list)
        {
        }

        public LocationList(IEnumerable<BaseEntity> list) : base(list.Cast<Location>().ToList())
        {
        }
    }
}
