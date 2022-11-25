using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Interfaces
{
    public interface IReview_Context
    {
        public Review_DTO AddReview(Review_DTO review_DTO);
        public List<Review_DTO> GetAllReviews(int itemid);
    }
}
