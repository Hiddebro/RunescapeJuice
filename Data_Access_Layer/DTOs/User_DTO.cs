using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class User_DTO
    {
        public int User_ID { get; set; }
        public int IsAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; init; }

        public User_DTO(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User_DTO(int user_ID)
        {
            User_ID = user_ID;
        }
        public User_DTO()
        {

        }
    }
}
