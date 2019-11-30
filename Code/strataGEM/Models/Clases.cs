using System.Collections.Generic;
using System.Data.SqlClient;

namespace strataGEM.Models
{
    public class Clases
    {
        public class BD
        {
            private static SqlConnection Conectar()
            {
                string strConn = "Server=.;Database=StrataGEM; Trusted_Connection=true";
                //string strConn = "Server=.;Database=StrataGEM;user id=alumno;password=alumno";
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

            public static void AgregarJuego(string Name, string Image, string Description, bool Destacado)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.AgregarJuego '" + Name + "', '" + Image + "', '" + Description + "', '" + Destacado + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }

            public static void AgregarReview(int IdGame, int Points, string Description, string UserName)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.AgregarReview '" + IdGame + "', '" + Points + "', '" + Description + "', '" + UserName + "'";
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }

            public static void EliminarJuego(int IdGame)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.EliminarJuego '" + IdGame + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }

            public static void EliminarUsuario(int IdUser)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.EliminarUsuario '" + IdUser + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }

            public static void PromedioReviewsXJuego(int IdGame)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.PromedioReviewsXJuego '" + IdGame + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }

            public static List<Review> Top5Reseñas()
            {
                List<Review> Top5 = new List<Review>();
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.Top5Reseñas";
                SqlDataReader Lector = Consulta.ExecuteReader();
                while (Lector.Read())
                {
                    int Review_Id = (int)Lector["Id_Reseña"];
                    int Game_Id = (int)Lector["Id_Juego"];
                    int Review_Rating = (int)Lector["Puntaje_Dado"];
                    string User_Id = (string)Lector["Puntaje_Dado"];
                    string Review_Description = (Lector["Descripcion"].ToString());
                    int Review_Likes = (int)Lector["LikeDislike"];
                    string UserName = (string)Lector["UserName"];

                    Review UnJuego = new Review(Review_Id, Game_Id, Review_Rating, Review_Description, User_Id, Review_Likes, UserName);
                    Top5.Add(UnJuego);
                }
                Desconectar(Conn);
                return Top5;
            }

            public static Game TraerJuego(int IdGame)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.TraerJuego'" + IdGame + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Game Juego = new Game();
                while (Lector.Read())
                {
                    int Game_Id = (int)Lector["IdGame"];
                    string Game_Name = (Lector["Name"].ToString());
                    string Game_Image = (Lector["Image"].ToString());
                    string Game_Description = (Lector["Description"].ToString());
                    int Game_Average = (int)Lector["PromedioValor"];
                    bool Game_Highlight = (bool)Lector["Destacado"];

                    Juego = new Game(Game_Id, Game_Name, Game_Image, Game_Description, Game_Average, Game_Highlight);
                }
                Desconectar(Conn);
                return Juego;
            }

            public static Review TraerReview(int IdReview)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.TraerReview'" + IdReview + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                Review UnaReview = new Review();
                while (Lector.Read())
                {
                    int IdR = (int)Lector["Id_Reseña"];
                    int IdG = (int)Lector["Id_Juego"];
                    int Points = (int)Lector["Puntaje_Dado"];
                    string Desc = (Lector["Descripcion"].ToString());
                    string IdUs = (Lector["User_Id"].ToString());
                    int Likes = (int)Lector["LikeDislike"];
                    string UserName = (Lector["UserName"].ToString());

                    UnaReview = new Review(IdR, IdG, Points, Desc, IdUs, Likes, UserName);
                }
                Desconectar(Conn);
                return UnaReview;
            }

            public static List<Game> TraerJuegos()
            {
                List<Game> ListGames = new List<Game>();
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.TraerJuegos";
                SqlDataReader Lector = Consulta.ExecuteReader();
                while (Lector.Read())
                {
                    int Game_Id = (int)Lector["IdGame"];
                    string Game_Name = (Lector["Name"].ToString());
                    string Game_Image = (Lector["Image"].ToString());
                    string Game_Description = (Lector["Description"].ToString());
                    int Game_Average = (int)Lector["PromedioValor"];
                    bool Game_Highlight = (bool)Lector["Destacado"];

                    Game UnJuego = new Game(Game_Id, Game_Name, Game_Image, Game_Description, Game_Average, Game_Highlight);
                    ListGames.Add(UnJuego);
                }
                Desconectar(Conn);
                return ListGames;
            }

            public static List<Review> TraerReseñasXJuego(int IdGame)
            {
                List<Review> ListRev = new List<Review>();
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.TraerReseñas'" + IdGame + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                while (Lector.Read())
                {
                    int Review_Id = (int)Lector["Id_Reseña"];
                    int Game_Id = (int)Lector["Id_Juego"];
                    int Review_Rating = (int)Lector["Puntaje_Dado"];
                    string User_Id = (string)Lector["User_Id"];
                    string Review_Description = (Lector["Descripcion"].ToString());
                    int Review_Likes = (int)Lector["LikeDislike"];
                    string UserName = (string)Lector["UserName"];

                    Review UnJuego = new Review(Review_Id, Game_Id, Review_Rating, Review_Description, User_Id, Review_Likes, UserName);
                    ListRev.Add(UnJuego);
                }
                Desconectar(Conn);
                return ListRev;
            }

            public static void UpdateReview(int id, int Punt, string Desc)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.UpdateReview '" + Desc + "', '" + Punt + "', '" + id + "'";
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }

            public static bool YaReview(string id, int juego)
            {
                bool yatiene = false;
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "SELECT * FROM Reviews WHERE User_Id = '" + id + "' and Id_Juego = '" + juego + "'";
                SqlDataReader Lector = Consulta.ExecuteReader();
                while (Lector.Read())
                {
                    yatiene = true;
                }
                Desconectar(Conn);
                return yatiene;
            }

            public static void AssignRole(string id)
            {
                SqlConnection Conn = Conectar();
                SqlCommand Consulta = Conn.CreateCommand();
                Consulta.CommandType = System.Data.CommandType.Text;
                Consulta.CommandText = "Exec dbo.AssignRole '" + id + "'";
                Consulta.ExecuteNonQuery();
                Desconectar(Conn);
            }
        }
    }
}