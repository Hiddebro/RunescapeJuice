using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer.Models
{
    public class User_Model
    {
        public bool IsAdmin { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty ;
        public string Email { get; set; } = string.Empty;

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

        public User_Model(string username, string password)
        {
            Username = username;
            Password = password;
            
        }
        public User_Model()
        {
            
        }

       
    }
}
