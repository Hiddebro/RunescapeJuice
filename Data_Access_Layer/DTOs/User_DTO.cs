using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public record User_DTO
    {
        public int User_ID { get; set; }
        public int IsAdmin { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; init; } = string.Empty;

        public User_DTO(string username, string password)
        {
            Username = username;
            Password = password;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User_DTO(int user_ID)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            User_ID = user_ID;
        }
        public User_DTO()
        {

        }
    }
}
