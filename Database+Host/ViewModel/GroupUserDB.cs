using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ViewModel
{
    public class GroupUserDB:BaseDB
    {
        public static GroupUserList lgroupu =null;
        public static GroupUser groupu = null;

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            GroupUser groupu = entity as GroupUser;
            groupu.ID = (int)reader["ID"];
            groupu.User = (Person)reader["User"];
            groupu.Group = (Group)reader["Group"];
            return groupu;
        }

        protected override BaseEntity NewEntity()
        {
            return new GroupUser() as BaseEntity;
        }

        public static GroupUser SelectByID(int id)
        {
            if (lgroupu==null)
            {
                GroupUserDB db = new GroupUserDB();
                lgroupu = db.SelectAll();
            }
            GroupUser groupu = lgroupu.Find(c => c.ID == id);
            return groupu;
        }
        public  GroupUserList SelectByPerson(Person p)
        {
            lgroupu = new GroupUserList();
            cmd.CommandText = "SELECT  * From GroupUser WHERE User = @p";
            cmd.Parameters.Add(new OleDbParameter("@p",p.ID));
            lgroupu = new GroupUserList(base.Select());
            return lgroupu;

            //if (lgroupu == null)
            //{
            //    GroupUserDB db = new GroupUserDB();
            //    lgroupu = db.SelectAll();
            //}
            //GroupUserList gul = new GroupUserList(lgroupu.FindAll(gu => gu.User == p));
            //return gul;
        }

        public override void Delete(BaseEntity entity)
        {
            GroupUser gu = entity as GroupUser;
            base.Delete(gu);
        }


        public GroupUserList SelectAll()
        {
            lgroupu = new GroupUserList();
            cmd.CommandText = "SELECT  * From GroupUser";
            lgroupu = new GroupUserList(base.Select());
            return lgroupu;
        }

        protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            GroupUser g = entity as GroupUser;

            cmd.CommandText = "INSERT INTO GroupUser (User,Group) VALUES(@User,@Group)";
            cmd.Parameters.Add(new OleDbParameter("@User", g.User));
            cmd.Parameters.Add(new OleDbParameter("@Group", g.Group));

        }
        protected override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            GroupUser g = entity as GroupUser;
            cmd.CommandText = "UPDATE GroupUser SET User=@User,Group=@Group WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@User", g.User));
            cmd.Parameters.Add(new OleDbParameter("@Group", g.Group));

        }

        protected override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            GroupUser g = entity as GroupUser;
            cmd.CommandText = "DELETE FROM GroupUser WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@ID", g.ID));
        }
    }
}
