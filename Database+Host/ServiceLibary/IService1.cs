using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Model;
using ViewModel;

namespace ServiceLibary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        Person LogIn(string uname, string pass);
        [OperationContract]
        int InsertPerson(Person person);
        [OperationContract]
        STypeList SelectAllTypes();
        [OperationContract]
        PersonList SelectAllPersons();
        [OperationContract]
        void UpdatePerson(Person p);
        [OperationContract]
        void Delete(Person p);

        [OperationContract]
        CommentsList SelectAllC();

        [OperationContract]
        LocationList SelectAllL();
        [OperationContract]
        void comment_creator(Person p, Location loc);

        [OperationContract]
        CommentsList SelectCbyP(Person p);

        [OperationContract]
         LocationList Lby_Person(Person p);
        [OperationContract]
        LTypeList all_l_types();
        [OperationContract]
        byte[] GetImage(string fileName);

        [OperationContract]
        void SaveImage(byte[] imgArray, string fileName);
        [OperationContract]
        int Create_Location(Location loc);

        [OperationContract]
        void DeleteC(Comments c);

        [OperationContract]
        void DeleteL(Location l);


    }



}
