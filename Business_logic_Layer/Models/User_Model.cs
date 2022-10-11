using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer.Models
{
    public class User_Model
    {
        public int User_ID { get; set; }
        public bool IsAdmin { get; set; }
        public string Username { get; set; } 
        public string Password { get; set; } 
        public string Email { get; set; }

        public User_Model(bool isadmin, string username, string password, string email)
        {
            IsAdmin = isadmin;
            Username = username;
            Password = password;
            Email = email;
        }

        public User_Model(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public User_Model(string username, string password, int user_ID)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            Username = username;
            Password = password;
            User_ID = user_ID;
            
        }
        public User_Model()
        {
            
        }

       
    }
}
