using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using Model;

namespace ViewModel
{
    public abstract class BaseDB
    {
        private static string connectionstr;//= @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\YuvalProject\ViewModel\DataBase\YuvalDataBase.accdb;Persist Security Info=True";
        protected OleDbConnection con;
        protected OleDbCommand cmd;
        protected OleDbDataReader reader;
        protected static List<EntityChange> insert = new List<EntityChange>();
        protected static List<EntityChange> update = new List<EntityChange>();
        protected static List<EntityChange> delete = new List<EntityChange>();

        public BaseDB()
        {
            if (connectionstr == null)
            {  connectionstr = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = "+path()+ @"\DataBase\Database11.accdb; Persist Security Info = True"; }

            con = new OleDbConnection(connectionstr);
            cmd = new OleDbCommand();
            cmd.Connection = con;
        }
        public static String path()
        {
             
                String[] arguments = Environment.GetCommandLineArgs();
                string s;
                if (arguments.Length == 1)
                { s = arguments[0]; }
                else 
                {
                    s = arguments[1];
                    s = s.Replace("/service:", "");  
                }
                string[] ss = s.Split('\\');   

                int x = ss.Length - 4;  
                ss[x] = "ViewModel";   
                Array.Resize(ref ss, x + 1); 
              string  s1 = String.Join("\\", ss);  
            return s1;
            
        }

        

        protected abstract BaseEntity NewEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);
        protected abstract void CreateInsertSql(BaseEntity entity,OleDbCommand cmd);
        protected abstract void CreateUpdateSql(BaseEntity entity,OleDbCommand cmd);
        protected abstract void CreateDeleteSql(BaseEntity entity,OleDbCommand cmd);

        public virtual void Insert(BaseEntity entity)
        {
            BaseEntity entitycheck = this.NewEntity();
            if (entity!=null && entity.GetType()==entitycheck.GetType())
            {
                insert.Add(new EntityChange(entity, this.CreateInsertSql));
            }
        }

        public virtual void Update(BaseEntity entity)
        {
            BaseEntity entitycheck = this.NewEntity();
            if (entity != null && entity.GetType() == entitycheck.GetType())
            {
                update.Add(new EntityChange(entity, this.CreateUpdateSql));
            }
        }


        public virtual void Delete(BaseEntity entity)
        {
            BaseEntity entitycheck = this.NewEntity();
            if (entity != null && entity.GetType() == entitycheck.GetType())
            {
                delete.Add(new EntityChange(entity, this.CreateDeleteSql));
            }
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                cmd.Connection = con;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (con.State.Equals(ConnectionState.Open) == true)
                {
                    con.Close();
                }
            }
            return list;
        }

        public int SaveChanges()
        {
            int affected = 0;
            con.Open();
            try
            {
                foreach (var entity in insert)
                {
                    cmd.Parameters.Clear();
                    entity.Sql(entity.Entity, cmd);
                    affected = affected + cmd.ExecuteNonQuery();
                    cmd.CommandText = "Select @@Identity";
                    entity.Entity.ID = (int)cmd.ExecuteScalar();
                }
                insert.Clear();
                foreach (var entity in update)
                {
                    cmd.Parameters.Clear();
                    entity.Sql(entity.Entity, cmd);
                    affected = affected + cmd.ExecuteNonQuery();
                }
                update.Clear();
                foreach (var entity in delete)
                {
                    cmd.Parameters.Clear();
                    entity.Sql(entity.Entity, cmd);
                    affected = affected + cmd.ExecuteNonQuery();
                }
                delete.Clear();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message+"\nSQL:"+cmd.CommandText);
            }
            finally
            {
                if (ConnectionState.Open==con.State)
                {
                    con.Close();
                }
                insert.Clear();
                update.Clear();
                delete.Clear();
            }
            return affected;
        }
        
    }
}
