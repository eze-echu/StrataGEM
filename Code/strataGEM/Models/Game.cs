namespace strataGEM.Models
{
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
}