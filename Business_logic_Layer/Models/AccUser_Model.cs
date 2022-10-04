using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer.Models
{
    public class AccUser_Model
    {
        public int User_ID { get; set; }
        public int IsAdmin { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Registrated { get; set; }

        public AccUser_Model(int user_ID, int isAdmin,string username, string password, string email, int registrated)
        {
            User_ID = user_ID;
            IsAdmin = isAdmin;
            Username = username;
            Password = password;
            Email = email;
            Registrated = registrated;
        }

        public AccUser_Model(string username, string password, string email)
        {
            Username = username;
            Password= password;
            Email = email;
        }
        
        public AccUser_Model()
        {

        }
    }
}
