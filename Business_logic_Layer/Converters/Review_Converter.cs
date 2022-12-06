using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;

namespace Business_logic_Layer.Converters
{
    public class Review_Converter
    {
        public Review_Model DtoToModel(Review_DTO dto)
        {
            Review_Model review_Model = new Review_Model(dto.ItemID, dto.Review, dto.Score);
            return review_Model;
        }

        public Review_DTO ModelToDTO(Review_Model model)
        {
            Review_DTO dto = new Review_DTO()
            {
                ItemID = model.ItemID,
                Score = model.Score,
                Review = model.Review
            };
            return dto;
        }
    }
}
