using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;

namespace Business_logic_Layer.Converters
{
    public class User_Converter
    {
        public User_Model DtoToModel(User_DTO dto)
        {
            User_Model user_Model = new User_Model(dto.Username, dto.Password, dto.User_ID, dto.IsAdmin);
            return user_Model;
        }

        public User_DTO ModelToDTO(User_Model model)
        {
            User_DTO dto = new User_DTO()
            {
                Username = model.Username,
                Password = model.Password,
                User_ID = model.User_ID,
                IsAdmin = model.IsAdmin
            };
            return dto;
        }

    }
}

