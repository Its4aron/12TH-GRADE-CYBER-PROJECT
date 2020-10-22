using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model

{
    public class Person : BaseEntity
    {
        private string username;
        private string password;
        private DateTime syears;
        private Boolean trusted;
        private Boolean admin;
        private string email;
        private STypes stype;


        public string Username { get => username; set => username = value;}
        public string Password { get => password; set => password = value; }
        public DateTime SYears { get => syears; set => syears = value; }
        public Boolean Trusted { get => trusted; set => trusted = value; }
        public Boolean Admin { get => admin; set => admin = value; }
        public string Email { get => email; set => email = value; }
        public STypes SType { get => stype; set => stype = value; }



    }
}
