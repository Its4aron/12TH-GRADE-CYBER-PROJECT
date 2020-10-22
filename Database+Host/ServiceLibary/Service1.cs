using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;
using System.Drawing;


namespace ServiceLibary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        public Person LogIn(string uname, string pass)
        {
            PersonDB db = new PersonDB();
            return db.LogIn(uname, pass);
        }
        public int InsertPerson(Person person)
        {
            PersonDB db = new PersonDB();
           
            db.Insert(person);
           int x= db.SaveChanges();
            if (x > 0)
            { return person.ID; }

            else


                return -1;
        }
        public STypeList SelectAllTypes()
        {
            STypeDB db = new STypeDB();
            STypeList l = new STypeList();
            l = db.SelectAll();
            return l;
            

        }
        public void DeleteC(Comments c)
        {
            CommentsDB db = new CommentsDB();
            db.Delete(c);
            db.SaveChanges();
        }
        public void DeleteL(Location l)
        {
            LocationDB db = new LocationDB();
            db.Delete(l);
            db.SaveChanges();
        }
        public PersonList SelectAllPersons()
        {
            PersonDB db = new PersonDB();
            PersonList l = new PersonList();
            l = db.SelectAll();
            return l;
        }
       
        public void UpdatePerson(Person p)
        
        {
            PersonDB db = new PersonDB();
            db.Update(p);
            db.SaveChanges();

        }
        public void Delete(Person p)
        {
            PersonDB db = new PersonDB();
            db.Delete(p);
            db.SaveChanges();
        }

        public LocationList Lby_Person(Person p)
        {
            LocationDB db = new LocationDB();
            LocationList l = new LocationList();
            l = db.Locationby_person(p);
            return l;
        }


        public LTypeList all_l_types()
        {
            LTypeDB db = new LTypeDB();
            LTypeList list = db.SelectAll();
            return list;
        }


        public CommentsList SelectAllC()
        {
            CommentsDB db = new CommentsDB();
            CommentsList l = new CommentsList();
            l = db.SelectAll();
            return l;
        }
        public void comment_creator(Person p, Location loc)
        {
            //Creates a Commment for person by his location to have a connection.
            LocationDB db = new LocationDB();
            DateTime Date = DateTime.Today;
            string c = "";
            Comments com = new Comments();
            com.Cdate = Date;
            com.Comment = c;
            com.Creator = p;
            com.Loc = loc;
            db.Insert(com);
           
        }

        public LocationList SelectAllL()
        {
            LocationDB db = new LocationDB();
            LocationList l = new LocationList();
            l = db.SelectAll();
            return l;
        }

        public CommentsList SelectCbyP(Person p)
        {
            CommentsDB db = new CommentsDB();
            CommentsList l = new CommentsList();
            l = db.CommentsByPerson(p);
            return l;
            
        }
        public byte[] GetImage(string fileName)
        {
            string path = BaseDB.path()+"/Images/" + fileName;
            byte[] imgArray = File.ReadAllBytes(path);


            return imgArray;
        }

        public void SaveImage(byte[] imageArray, string fileName)
        {
            var stream = new MemoryStream(imageArray);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
 
            string localFilePath = BaseDB.path()+ "/Images/" + fileName;
            img.Save(localFilePath);
        }
        public int Create_Location(Location loc) { 
            LocationDB db = new LocationDB();
            db.Insert(loc);
            int x = db.SaveChanges();
            if (x > 0)
            { return loc.ID; }
            else
                return -1;
        }


    }
}
