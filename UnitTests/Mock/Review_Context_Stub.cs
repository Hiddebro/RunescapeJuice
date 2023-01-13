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
        public Review_DTO? AddReview(Review_DTO review)
        {
            Review_DTO review2 = new Review_DTO();
            review2.Review = "lelijk";
            review2.ReviewID = 1;
            review2.Score = 5;
            review2.ItemID = 1;
            reviews.Add(review2);
            if (review.ItemID == review2.ItemID)
            {
                
                 return review2;
            }
             return review;
        }
        public List<Review_DTO> GetAllReviews(int itemid)
        {
            if (itemid == 1)
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
            return reviews;
        }

        public bool AddLike(int reviewid, int userid)
        {
            Review_DTO reviewLike4 = new Review_DTO();
            reviewLike4.Like = 1;
            reviewLike4.UserID = 2;
            reviews.Add(reviewLike4);
            return true;
        }

        public List<Review_DTO> GetAllLikes(int reviewid)
        {
            
            Review_DTO reviewLike = new Review_DTO();
            reviewLike.Like = 1;
            reviewLike.UserID = 1;
            reviews.Add(reviewLike);

            Review_DTO reviewLike2 = new Review_DTO();
            reviewLike2.Like = 1;
            reviewLike2.UserID = 2;
            reviews.Add(reviewLike2);

            Review_DTO reviewLike3 = new Review_DTO();
            reviewLike3.Like = 1;
            reviewLike3.UserID = 2;
            reviews.Add(reviewLike3);

            
            return reviews;
        }
    }
}
