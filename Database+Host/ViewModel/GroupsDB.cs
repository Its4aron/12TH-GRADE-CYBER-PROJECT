using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class GroupsDB:BaseDB
    {
        public static Group group =null;
        public static GroupList groupl = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Group group = entity as Group;
            group.ID = (int)reader["ID"];
            group.Groupname = reader["GroupName"].ToString();
            group.Pic = reader["Pic"].ToString();
            group.Groupdate = (DateTime)reader["GroupDate"];
            return group;
        }

        
        protected override BaseEntity NewEntity()
        {
            return new STypes() as BaseEntity;
        }

        public static Group SelectByID(int id)
        {
            if (groupl==null)  
            {
                GroupsDB db = new GroupsDB();
                groupl= db.SelectAll();
            }
            Group group = groupl.Find(c => c.ID == id);
            return group;
        }

        public GroupList SelectAll()
        {
            groupl = new GroupList();
            cmd.CommandText = "SELECT  * From Groups";
            groupl = new GroupList(base.Select());
            return groupl;
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
