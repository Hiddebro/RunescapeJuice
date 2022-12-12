using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class Review_DTO
    {
        public int ItemID { get; set; }
        public string Review { get; set; }
        public int Score { get; set; }

        public Review_DTO()
        {

        }
    }
}
