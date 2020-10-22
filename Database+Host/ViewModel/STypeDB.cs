using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class STypeDB:BaseDB
    {
        public static STypeList Stypes =null; 
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            STypes sType = entity as STypes;
            sType.ID = (int)reader["ID"];
            sType.Type = reader["Type"].ToString();
            return sType;
        }

        protected override BaseEntity NewEntity()
        {
            return new STypes() as BaseEntity;
        }

        public static STypes SelectByID(int id)
        {
            if (Stypes==null)
            {
                STypeDB db = new STypeDB();
                Stypes = db.SelectAll();
            }
            STypes STypes = Stypes.Find(c => c.ID == id);
            return STypes;
        }

        public STypeList SelectAll()
        {
            Stypes = new STypeList();
            cmd.CommandText = "SELECT  * From Stypes";
            Stypes = new STypeList(base.Select());
            return Stypes;
        }

        protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            STypes c = entity as STypes;
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
