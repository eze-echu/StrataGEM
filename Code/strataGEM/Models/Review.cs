using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strataGEM.Models
{
    public class Review
    {
        private int _Review_Id;
        private int _Review_IdGame;
        private int _Review_Likes;
        private string _Review_UserName;
        private string _Review_IdUser;
        public int Review_Rating { get; set; }
        public string Review_Description { get; set; }
        public int Review_Id { get => _Review_Id; }
        public int Review_IdGame { get => _Review_IdGame; }
        public int Review_Likes { get => _Review_Likes; }
        public string Review_UserName { get => _Review_UserName; }
        public string Review_IdUser { get => _Review_IdUser; }

        public Review(int a, int b, int c, string d, string e, int f, string g)
        {
			_Review_Id = a;
            _Review_IdGame = b;
            Review_Rating = c;
            Review_Description = d;
            _Review_IdUser = e;
            _Review_Likes = f;
            _Review_UserName = g;
        }
        public Review()
        {

        }

    }

}