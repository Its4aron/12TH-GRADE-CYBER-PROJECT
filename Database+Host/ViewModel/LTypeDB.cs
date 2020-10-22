using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class LTypeDB:BaseDB
    {
      
        public static LTypeList Ltypes = null; 
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            LType type = entity as LType;
            type.ID = (int)reader["ID"];
            type.Type = reader["type"].ToString();
            return type;
               
        }

        protected override BaseEntity NewEntity()
        {
            return new LType() as BaseEntity;
        }

        //public static LType SelectByID(int id)
        //{
        //    if (lTypes==null)
        //    {
        //        LTypeDB db = new LTypeDB();
        //        Types = db.SelectAll();
        //    }
        //    LType lTypes = lTypes.Find(c => c.ID == id);
        //    return lTypes;
        //}

        public  LType SelectByID(int id)
        {
            if (Ltypes == null)
            {
                LTypeDB db = new LTypeDB();
                Ltypes = db.SelectAll();
            }
        //    LType xx=null;
        //    foreach (LType lt in Ltypes)
        //    { 
        //        if ( lt.ID == id)
        //            xx = lt;
        //}

            LType fl = Ltypes.Find(lt => lt.ID == id);
            return fl;
           
        }
       

        public LTypeList SelectAll()
        {
            Ltypes = new LTypeList();
            cmd.CommandText = "SELECT  * From LTypes";
            Ltypes = new LTypeList(base.Select());
            return Ltypes;
        }

        protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            LType c = entity as LType;
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
