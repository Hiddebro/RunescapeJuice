using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;

namespace Business_logic_Layer.Container
{
    public class Review_Container
    {
        private IReview_Context Review_Context;
        private readonly Review_Converter converterR = new Review_Converter();

        public Review_Container(IReview_Context context)
        {
            this.Review_Context = context;
        }
        public Review_Model AddReview(Review_Model review_Model)
        {
            Review_DTO dto = converterR.ModelToDTO(review_Model);
            return converterR.DtoToModel(Review_Context.AddReview(dto));
        }
        public List<Review_Model> GetAllReviews(int itemid)
        {
            Review_Model review = new Review_Model();
            List<Review_Model> reviews = new List<Review_Model>();
            List<Review_DTO> DTOs = Review_Context.GetAllReviews(itemid);
            foreach (var dto in DTOs)
            {
                review = converterR.DtoToModel(dto);
                reviews.Add(review);
            }


            return reviews;
        }
    }
}
