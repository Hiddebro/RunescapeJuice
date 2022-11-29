using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Data.SqlClient;

namespace Data_Access_Layer.Context
{
    public class Review_Context : SQLBaseContext, IReview_Context
    {
        public Review_DTO AddReview(Review_DTO review_DTO)
        {
            try
            {
                ConOpen();
                var sql = "INSERT INTO[dbo].[Reviews] ([Score] ,[Review] ,[ItemID]) VALUES (@Score, @review,@ItemID)";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemID", review_DTO.ItemID);
                cmd.Parameters.AddWithValue("@Score", review_DTO.Score);
                cmd.Parameters.AddWithValue("@Review", review_DTO.Review);
                cmd.ExecuteNonQuery();


                Console.WriteLine("Succesful Item Added");
                return review_DTO;
            }

            catch (Exception ex)
            {

            }
            throw new NotImplementedException();
        }

        public List<Review_DTO> GetAllReviews(int itemid)
        {
            List<Review_DTO> list = new List<Review_DTO>();
            try
            {
                Review_DTO review = null;
                ConOpen();
                var sql = "SELECT * FROM Reviews WHERE ItemID = @ItemID";
                SqlCommand cmd = new SqlCommand(sql, this.Con);
                cmd.Parameters.AddWithValue("@ItemID", itemid);
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    review = new Review_DTO();
                    {

                        review.ItemID = rdr.GetInt32("ItemID");
                        review.Review = rdr.GetString("Review");
                        review.Score = rdr.GetInt32("Score");
                    };

                    list.Add(review);

                }


            }
            catch (Exception ex)
            {

            }


            return list;
        }
    }
}

