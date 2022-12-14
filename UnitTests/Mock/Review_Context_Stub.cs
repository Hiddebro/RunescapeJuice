using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Context
{
    public class Review_Context_Stub : IReview_Context
    {
        public List<Review_DTO> reviews = new List<Review_DTO>();


        public Review_Context_Stub()
        {

        }
        public Review_DTO AddReview(Review_DTO review)
        {
            return review;
        }
        public List<Review_DTO> GetAllReviews(int itemid)
        {
            Review_DTO review = new Review_DTO();
            review.Review = "mooi";
            review.Score = 5;
            review.ItemID = 1;
            reviews.Add(review);

            Review_DTO review2 = new Review_DTO();
            review2.Review = "lelijk";
            review2.Score = 1;
            review2.ItemID = 1;
            reviews.Add(review2);

            return reviews;
        }

        public bool AddLike(int reviewid, int userid)
        {
            return true;
        }

        public int GetAllLikes(int reviewid)
        {
            int count = 0;
            return count;
        }
    }
}
