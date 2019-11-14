using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace strataGEM.Models
{
    public class Clases
    {
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
            public int Game_Average { get; set; }
            public bool Game_Highlight { get; set; }

            public Game(int a, string b, string c, string d, int e, bool f)
            {
                Game_Id = a;
                Game_Name = b;
                Game_Image = c;
                Game_Description = d;
                Game_Average = e;
                Game_Highlight = f;
            }
            public Game()
            {

            }

        }
        public class BD
        {
            private static SqlConnection Conectar()
            {
                //string strConn = "Server=.;Database=StrataGEM;TrustedConnection=True";
                string strConn = "Server=.;Database=StrataGEM;user id=alumno;password=alumno";
                SqlConnection a = new SqlConnection(strConn);
                a.Open();
                return a;
            }
            private static void Desconectar(SqlConnection Conn)
            {
                Conn.Close();
            }
            public static Game TraerJuegoPop()
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.TraerJuegoPop";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Game Pop = new Game();
                while (Lector.Read())
                {
                    int Game_Id = (int)Lector["IdGame"];
                    string Game_Name = (Lector["Name"].ToString());
                    string Game_Image = (Lector["Image"].ToString());
                    string Game_Description = (Lector["Description"].ToString());
                    int Game_Average = (int)Lector["PromedioValor"];
                    bool Game_Highlight = (bool)Lector["Destacado"];
                    Pop = new Game(Game_Id, Game_Name, Game_Image, Game_Description, Game_Average, Game_Highlight);

                }
                Desconectar(Conn);
                return Pop;
            }
        }
        
    }
}