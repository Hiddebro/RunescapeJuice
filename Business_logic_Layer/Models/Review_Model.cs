namespace Business_logic_Layer.Models
{
    public class Review_Model
    {
        public int ItemID { get; set; }
        public string Review { get; set; }
        public int Score { get; set; }
        public int ReviewID { get; set; }
        public int Like { get; set; }
        public int UserID { get; set; }


        public Review_Model(int itemID, string review, int score, int reviewID)
        {
            ItemID = itemID;
            Review = review;
            Score = score;
            ReviewID = reviewID;
        }
        public Review_Model(int reviewID, int userID)
        {
            ReviewID = reviewID;
            UserID = userID;
        }

        public Review_Model(int reviewID)
        {
            ReviewID = reviewID;
        }

    }
}
