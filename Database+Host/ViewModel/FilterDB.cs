using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class FilterDB:BaseDB
    {  
            protected override BaseEntity CreateModel(BaseEntity entity)
            {
                Filter filter = entity as Filter;
                filter.ID = (int)reader["ID"];
                PersonDB db = new PersonDB();
                filter.Person_f = db.SelectById((int)reader["Person_f"]);
                return filter;
            }

            protected override BaseEntity NewEntity()
            {
                return new Filter() as BaseEntity;
            }

            protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
            {
                Filter p = entity as Filter;
            }

            protected override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
            {
                throw new NotImplementedException();
            }

            protected override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
            {
                throw new NotImplementedException();
            }
        }
    }


}
