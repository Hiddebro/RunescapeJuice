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
        public User_DTO GetByIsAdmin(User_DTO user)
        {
            User_DTO dto = new User_DTO();
            if(user.User_ID == 1)
            {
               user.IsAdmin= 1;
                dto = user;
            }

            if (user.User_ID ==3)
            {
                user.IsAdmin = 0;
                dto = user;
            }
            return dto;
        }
        public bool CheckActorr(User_DTO user)
        {
            return true;
        }

        public User_DTO GetAllUserItems(User_DTO user)
        {
            return null;
        }

        public void SellItem(int id)
        {
            
        }
    }
}
