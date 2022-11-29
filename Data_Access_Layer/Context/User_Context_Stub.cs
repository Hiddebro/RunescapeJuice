using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Context
{
    public class User_Context_Stub : IUser_Context
    {
        public static List<User_DTO> users = new List<User_DTO>();
        User_DTO user = new User_DTO();
        public static bool tryaddperson;
        public User_Context_Stub()
        {
            User_DTO user = new User_DTO();
            user.User_ID = 1;
            user.IsAdmin = 1;
            user.Username = "Henk";
            user.Password = "Boos";
            users.Add(user);
        }
        public User_DTO AddUser(User_DTO user)
        {
            return user;
        }
        public User_DTO GetByName(User_DTO user)
        {
            
            User_DTO dto = new User_DTO();
            if (user.Username == "Henk" && user.Password == "Boos")
            {
                user.User_ID = 1;
                user.IsAdmin = 1;
                dto = user;
            }
           
            return dto;
        }
 
    }
}
