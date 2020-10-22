using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Filter : BaseEntity
    {
        private Person person_f;

        public Person Person_f { get => person_f; set => person_f = value; }
    }
}
