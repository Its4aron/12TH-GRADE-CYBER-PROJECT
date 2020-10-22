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

    public class PictureList:List<Picture>
    {
        public PictureList()
        {

        }

        public PictureList(IEnumerable<Picture> list) : base(list)
        {
        }

        public PictureList(IEnumerable<BaseEntity> list) : base(list.Cast<Picture>().ToList())
        {
        }
    }
}
