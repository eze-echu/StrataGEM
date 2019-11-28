using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace strataGEM.Models
{
    public class Review
    {
            public int Review_Id { get; set; }
            public int Review_IdGame { get; set; }
            public int Review_Rating { get; set; }
            public string Review_Description { get; set; }
            public string Review_IdUser { get; set; }
            public int Review_Likes { get; set; }
            public string Review_UserName { get; set; }

            public Review(int a, int b, int c, string d, string e, int f, string g)
            {
                Review_Id = a;
                Review_IdGame = b;
                Review_Rating = c;
                Review_Description = d;
                Review_IdUser = e;
                Review_Likes = f;
                Review_UserName = g;
            }
            public Review()
            {

            }

        }
}