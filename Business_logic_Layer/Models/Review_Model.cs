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

        public Review_Model(int itemID, string review, int score)
        {
            ItemID = itemID;
            Review = review;
            Score = score;
        }

    }
}
