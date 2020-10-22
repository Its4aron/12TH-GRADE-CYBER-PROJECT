using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;
using System.Data.OleDb;

namespace ViewModel
{
    public class PersonDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new Person();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            
            Person person = entity as Person;
            person.ID = (int)reader["ID"];
            person.Username = reader["Username"].ToString();
            person.Password = reader["Password"].ToString();
            person.SYears = (DateTime)reader["SYears"];
            person.SType = STypeDB.SelectByID((int)reader["SType"]);
            person.Email = (String)reader["Email"];
            person.Trusted = (bool)reader["Trusted"];
            person.Admin = (bool)reader["Admin"];
            return person;
        }


        protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Person person = entity as Person;
         //   cmd.CommandText = "INSERT INTO Person (Username, [Password], Email, Stypes, SYears*/, Trusted , Admin) VALUES(@Username,@Password,@STypes,@Email,@Admin/*,@SYears*/,@Trusted)";
            cmd.CommandText = "INSERT INTO Person (Username, [Password], Email, SType, SYears , Trusted , Admin) VALUES(@Username,@Password,@Email,@SYears,@SType,@Trusted,@Admin)";
            cmd.Parameters.Add(new OleDbParameter("@Username", person.Username));
            cmd.Parameters.Add(new OleDbParameter("@Password", person.Password));
            cmd.Parameters.Add(new OleDbParameter("@Email", person.Email));
            cmd.Parameters.Add(new OleDbParameter("@STypes", person.SType.ID));
            //cmd.Parameters.Add(new OleDbParameter("@SYears", person.SYears));
            cmd.Parameters.Add(new OleDbParameter("@SYears", person.SYears));

            cmd.Parameters.Add(new OleDbParameter("@Trusted", person.Trusted));
            cmd.Parameters.Add(new OleDbParameter("@Admin", person.Admin));
        }

        protected override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            Person person = entity as Person;
           // cmd.CommandText = "Update Person  SET Username=@Username,[Password]=@Password,Stypes=@SType,Admin@Admin,Trusted=@Trusted WHERE ID=@ID";
            cmd.CommandText = "UPDATE Person SET Username=@Username,[Password]=@Password,Email=@Email,SType=@SType,SYears=@SYears,Trusted=@Trusted,Admin=@Admin WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@Username", person.Username));
            cmd.Parameters.Add(new OleDbParameter("@Password", person.Password));
            cmd.Parameters.Add(new OleDbParameter("@Email", person.Email));
            cmd.Parameters.Add(new OleDbParameter("@SType", person.SType.ID));
            cmd.Parameters.Add(new OleDbParameter("@SYears", person.SYears));
            cmd.Parameters.Add(new OleDbParameter("@Trusted", person.Trusted));
            cmd.Parameters.Add(new OleDbParameter("@Admin", person.Admin));
            //cmd.Parameters.Add(new OleDbParameter("@SYears", person.SYears));
            cmd.Parameters.Add(new OleDbParameter("@ID", person.ID));

        }

        protected override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            Person person = entity as Person;
            cmd.CommandText = "DELETE FROM Person WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@ID", person.ID));
        }
        public PersonList SelectAll()
        {
            cmd.CommandText = "Select * FROM Person";
            return new PersonList(base.Select());
        }
        public Person SelectById(int id)
        {
            cmd.CommandText = "Select * FROM Person where id=@ID";
            cmd.Parameters.Add(new OleDbParameter("@ID", id));
            PersonList lst= new PersonList(base.Select());
            if (lst.Count == 1)
                return lst[0];
            else
                return null;
        }

        
        public override void Update(BaseEntity entity)
        {
           
            Person u = entity as Person;
            update.Add(new EntityChange(entity, this.CreateUpdateSql));
        }

        public override void Delete(BaseEntity entity)
        {
            Person u = entity as Person;
        
            GroupUserDB gudb = new GroupUserDB();
            GroupUserList gul = new GroupUserList();
            gul =  gudb.SelectByPerson(u);
            
            foreach(GroupUser g in gul)
            {
                gudb.Delete(g);
            }
            CommentsDB cdb = new CommentsDB();
            CommentsList lc = cdb.CommentsByPerson(u);
            foreach (Comments c in lc)
            {
                cdb.Delete(c);
            }
            MsgsDB mdb = new MsgsDB();
            MsgsList ml = new MsgsList();

            ml = mdb.MsgsBySender(u);
            foreach(Msgs m in ml)
            {
                mdb.Delete(m);
            }
            base.Delete(entity);
        }

        public Person LogIn(string username, string password)
        {
            cmd.CommandText = "Select * FROM Person WHERE  Username = @Username and [Password] = @Password";
            cmd.Parameters.Add(new OleDbParameter("@Username", username));
            cmd.Parameters.Add(new OleDbParameter("@Password", password));

            PersonList list = new PersonList(base.Select());
            if (list.Count == 1)
            {
                return list.ElementAt(0) as Person;
            }
            return null;
        }

        public override void Insert(BaseEntity entity)
        {
            Person p = entity as Person;
            if (p != null)
            {
                insert.Add(new EntityChange(entity, this.CreateInsertSql));
            }
        }


    }
}
