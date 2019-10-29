using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

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
            public string User_Password { set => _User_Password = value; }

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

        public class Review
        {
            public int Review_Id { get; set; }
            public int Review_IdGame { get; set; }
            public int Review_Rating { get; set; }
            public string Review_Description { get; set; }
            public int Review_IdUser { get; set; }


            public Review(int a, int b, int c, string d, int e)
            {
                Review_Id = a;
                Review_IdGame = b;
                Review_Rating = c;
                Review_Description = d;
                Review_IdUser = e;
            }
            public Review()
            {

            }

        }
        public class Game
        {
            public int Game_Id { get; set; }
            public string Game_Name { get; set; }
            public string Game_Image { get; set; }
            public string Game_Description { get; set; }

            public Game(int a, string b, string c, string d)
            {
                Game_Id = a;
                Game_Name = b;
                Game_Image = c;
                Game_Description = d;
            }
            public Game()
            {

            }
        }
        public class BD
        {
            private static SqlConnection Conectar()
            {
                string strConn = "Server=.;Database =BD;Trusted_Connection=True;";
                SqlConnection a = new SqlConnection(strConn);
                a.Open();
                return a;
            }
            private static void Desconectar(SqlConnection Conn)
            {
                Conn.Close();
            }
        }
        
    }
}