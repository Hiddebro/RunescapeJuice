using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer.Models
{
    public class Review_Model
    {
        public int ItemID { get; set; }
        public string Review { get; set; }
        public int Score { get; set; }
        public int ReviewID { get; set; }
        public int Like { get; set; }

        public Review_Model(int itemID, string review, int score, int reviewID)
        {
            ItemID = itemID;
            Review = review;
            Score = score;
            ReviewID = reviewID;
        }

        public Review_Model(int itemID)
        {
            ItemID = itemID;
        }

    }
}
