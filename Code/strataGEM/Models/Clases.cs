using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strataGEM.Models
{
    public class Clases
    {
        public class Usuarios
        {
            public int User_Id { get; set; }
            public string User_Name { get; set; }
            private string _User_Password { get; set; }
            public string User_Email { get; set; }
            public int User_Role { get; set; }
            public string User_Password {set => _User_Password = value; }

            public Usuarios()
            {

            }

            public Usuarios(int a, string b, string c, string d, int e)
            {
                User_Id = a;
                User_Name = b;
                User_Password = c;
                User_Email = d;
                User_Role = e;
            }
        }

        public class Role
        {
            public int Role_Id { get; set; }
            public string Role_Name { get; set; }

            public Role(int a, string b)
            {
                Role_Id = a;
                Role_Name = b;
            }
            public Role()
            {

            }
        }
    }
}