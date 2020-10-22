using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class PictureDB:BaseDB
    {
        public static Picture pic = null;
        public static PictureList lpic = null; 
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Picture pic = entity as Picture;
            pic.ID = (int)reader["ID"];
            pic.Pic = reader["Pic"].ToString();
            return pic;
        }

        protected override BaseEntity NewEntity()
        {
            return new STypes() as BaseEntity;
        }

        public static Picture SelectByID(int id)
        {
            if (lpic==null)
            {
                PictureDB db = new PictureDB();
                lpic= db.SelectAll();
            }
            Picture pic = lpic.Find(c => c.ID == id);
            return pic;
        }

        public PictureList SelectAll()
        {
             lpic = new PictureList();
            cmd.CommandText = "SELECT  * From Picture";
            lpic = new PictureList(base.Select());
            return lpic;
        }

        protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Picture p = entity as Picture;
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
