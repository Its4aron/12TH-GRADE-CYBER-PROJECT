using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace ViewModel
{
    public class LocationDB:BaseDB
    {
        public  LocationList locations =null; 
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Location loc = entity as Location;
            loc.ID = (int)reader["ID"];
            loc.Longitude = (double)reader["Longtidue"];
            loc.Altitude = (double)reader["Altitude"];
            loc.Des = reader["Des"].ToString();
            loc.Name = reader["Name"].ToString();
            LTypeDB db = new LTypeDB();
            loc.Type = db.SelectByID((int)reader["Type"]);
            return loc;
        }

        protected override BaseEntity NewEntity()
        {
            return new Location() as BaseEntity;
        }

        public  Location SelectByID(int id)
        {
            if (locations==null)
            {
                LocationDB db = new LocationDB();
                locations = db.SelectAll();
            }
            Location loc = locations.Find(c => c.ID == id);
            return loc;
        }

        public LocationList Locationby_person(Person p)
        {
            
            cmd.CommandText = "SELECT Distinct Location.* FROM(Location INNER JOIN  Comment ON Location.ID = Comment.Location)"+
                "WHERE Comment.Creator =@id";
            cmd.Parameters.Add(new OleDbParameter("@id", p.ID));
            LocationList l = new LocationList(base.Select());
            return l;

           
        }
      
        public override void Delete(BaseEntity entity)
        {
            Location l = entity as Location;
            CommentsDB cdb = new CommentsDB();
            CommentsList cl = cdb.CommentsByLocation(l);
            foreach (Comments c in cl)
            {
                cdb.Delete(c);
            }
            base.Delete(l);
        }


        public LocationList SelectAll()
        {
            locations = new LocationList();
            cmd.CommandText = "SELECT  * From Location";
            locations = new LocationList(base.Select());
            return locations;
        }

        protected override void CreateInsertSql(BaseEntity entity, OleDbCommand cmd)
        {
            Location loc = entity as Location;
            cmd.CommandText = "INSERT INTO Location (Longtidue, Altitude, [Type], Des ,[Name]) VALUES(@Longtidue,@Altitdue,@Type,@Des,@Name)";
            cmd.Parameters.Add(new OleDbParameter("@Longtidue", loc.Longitude));
            cmd.Parameters.Add(new OleDbParameter("@Altitude", loc.Altitude));
            cmd.Parameters.Add(new OleDbParameter("@Type", loc.Type.ID));
            cmd.Parameters.Add(new OleDbParameter("@Des", loc.Des));
            cmd.Parameters.Add(new OleDbParameter("@Name", loc.Name));
        }

        protected override void CreateUpdateSql(BaseEntity entity, OleDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        protected override void CreateDeleteSql(BaseEntity entity, OleDbCommand cmd)
        {
            Location l = entity as Location;
            cmd.CommandText = "DELETE FROM Location WHERE ID=@ID";
            cmd.Parameters.Add(new OleDbParameter("@ID", l.ID));
        }
        public override void Insert(BaseEntity entity)
        {
            Location loc  = entity as Location;
            if (loc != null)
            {
                insert.Add(new EntityChange(entity, this.CreateInsertSql));
            }
        }
    }
}
