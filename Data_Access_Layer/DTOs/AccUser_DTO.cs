using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class AccUser_DTO
    {
        public int User_ID { get; set; }
        public int IsAdmin { get; set; }
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Email { get; init; } = String.Empty;
    }
}
