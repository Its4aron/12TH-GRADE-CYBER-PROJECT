using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel;
using System.Data.OleDb;

namespace ViewModel
{
    
    
        public class MsgsDB : BaseDB
        {
            public  MsgsList ml = null;
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Msgs msg = entity as Msgs;
            msg.ID = (int)reader["ID"];
            PersonDB db = new PersonDB();
            msg.Sender =db.SelectById((int)reader["Sender"]);
            msg.Txt = reader["Txt"].ToString();
            msg.TxtDate = (DateTime)reader["TxtDate"];
            msg.GroupID = (int)reader["GroupID"];
                return msg;
               
            }

            protected override BaseEntity NewEntity()
            {
                return new Msgs() as BaseEntity;
            }

            public Msgs SelectByID(int id)
            {
            ml = new MsgsList();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT  * From Msgs WHERE ID =@id";
            cmd.Parameters.Add(new OleDbParameter("@id",id));
            ml = new MsgsList(base.Select());
            if (ml.Count == 1)
                return ml[0];
            else
                return null;
        
        }
        public MsgsList MsgsBySender(Person p)
        {

            ml = new MsgsList();
            cmd.Parameters.Clear();
            cmd.CommandText = "SELECT  * From Msgs WHERE Sender =@p";
            cmd.Parameters.Add(new OleDbParameter("@p", p.ID));
            ml = new MsgsList(base.Select());
            return ml;

            //if (lcomments == null)
            //{
            //    CommentsDB db = new CommentsDB();
            //    lcomments = db.SelectAll();
            //}
            //CommentsList com = new CommentsList(lcomments.FindAll(c => c.Creator == p));
       
        }

        public override void Delete(BaseEntity entity)
        {
            Msgs u = entity as Msgs;
            base.Delete(u);
        }


        public MsgsList SelectAll()
            {
                ml = new MsgsList();
                cmd.CommandText = "SELECT  * From Msgs";
                ml = new MsgsList(base.Select());
                return ml;
            }

            protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
            {
                Msgs msg = entity as Msgs;
            cmd.CommandText = "INSERT INTO Msgs (Txt, Sender, TxtDate, GroupID)  VALUES  (@Txt,@Sender,@TxtDate,@GroupID)";
            cmd.Parameters.Add(new OleDbParameter("@Txt", msg.Txt));
            cmd.Parameters.Add(new OleDbParameter("@Sender", msg.Sender));
            cmd.Parameters.Add(new OleDbParameter("@TxtDate", msg.TxtDate));
            cmd.Parameters.Add(new OleDbParameter("@GroupID", msg.GroupID));
            //cmd.Parameters.Add(new OleDbParameter("@SYears", person.SYears));

        }

            protected override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
            {
            Msgs msg = entity as Msgs;

            cmd.CommandText = "UPDATE Msgs SET Txt=@Txt,Sender=@Sender,TxtDate=@TxtDate,GroupID=@GroupID WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@Txt", msg.Txt));
            cmd.Parameters.Add(new OleDbParameter("@Sender", msg.Sender));
            cmd.Parameters.Add(new OleDbParameter("@TxtDate", msg.TxtDate));
            cmd.Parameters.Add(new OleDbParameter("@GroupID", msg.GroupID));
        }

            protected override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
            {
                
            Msgs msgs = entity as Msgs;
            cmd.CommandText = "DELETE FROM Msgs WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@ID", msgs.ID));




        }
        }
    }


