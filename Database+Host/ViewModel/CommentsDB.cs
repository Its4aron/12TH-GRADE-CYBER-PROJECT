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
    
    
    
        public class CommentsDB : BaseDB
        {
            public  CommentsList lcomments = null;
            protected override BaseEntity CreateModel(BaseEntity entity)
            {
                Comments com = entity as Comments;
                com.ID = (int)reader["ID"];
                PersonDB db = new PersonDB();
                com.Creator =db.SelectById( (int)reader["Creator"]);
                com.Comment = reader["Comment"].ToString();
                com.Cdate = (DateTime)reader["Datee"];
                LocationDB dbl = new LocationDB();
                com.Loc = dbl.SelectByID((int)reader["Location"]);
                return com;
               
            }

            protected override BaseEntity NewEntity()
            {
                return new Comments() as BaseEntity;
            }

            public Comments SelectByID(int id)
            {
            lcomments = new CommentsList();
            cmd.CommandText = "SELECT  * From Comment WHERE ID =@id";
            cmd.Parameters.Add(new OleDbParameter("@id",id));
            lcomments = new CommentsList(base.Select());
            if (lcomments.Count == 1)
                return lcomments[0];
            else
                return null;
        
        }
        public CommentsList SelectByLocation (Location loc)
        {
           // PersonDB dbp = new PersonDB();
            //Person p = new Person();
            //p = dbp.SelectById(id);
        ///  lcomments = new CommentsList();
            cmd.CommandText = "SELECT  * From Comment WHERE Location =@loc";
            cmd.Parameters.Add(new OleDbParameter("@loc",loc));
            lcomments = new CommentsList(base.Select());
            return lcomments;

            //if (lcomments == null)
            //{
            //    CommentsDB db = new CommentsDB();
            //    lcomments = db.SelectAll();
            //}
            //CommentsList com = new CommentsList(lcomments.FindAll(c => c.Creator == p));

        }


        public CommentsList CommentsByPerson(Person p)
        {

            cmd.CommandText = "SELECT  * From Comment WHERE Creator =@p";
            cmd.Parameters.Add(new OleDbParameter("@p", p.ID));
            lcomments = new CommentsList(base.Select());
            return lcomments;

           
       
        }
        public CommentsList CommentsByLocation(Location l)
        {

            cmd.CommandText = "SELECT  * From Comment WHERE Location =@l";
            cmd.Parameters.Add(new OleDbParameter("@l", l.ID));
            lcomments = new CommentsList(base.Select());
            return lcomments;



        }

        public override void Delete(BaseEntity entity)
        {
            Comments c = entity as Comments;
            base.Delete(c);
        }


        public CommentsList SelectAll()
            {
                lcomments = new CommentsList();
                cmd.CommandText = "SELECT * From Comment";
                lcomments = new CommentsList(base.Select());
                return lcomments;
            }

            protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
            {
                Comments com = entity as Comments;
            cmd.CommandText = "INSERT INTO Comment (Creator, Comment, Location, Datee) VALUES(@Creator,@Comment,@Location,@Datee)";
            cmd.Parameters.Add(new OleDbParameter("@Creator", com.Creator));
            cmd.Parameters.Add(new OleDbParameter("@Comment", com.Comment));
            cmd.Parameters.Add(new OleDbParameter("@Location", com.Loc));
            cmd.Parameters.Add(new OleDbParameter("@Datee", com.Cdate));

        }

            protected override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
            {
                throw new NotImplementedException();
            }

            protected override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
            {
            Comments c = entity as Comments;
            cmd.CommandText = "DELETE FROM Comment WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@ID", c.ID));
        }
        }
    }


