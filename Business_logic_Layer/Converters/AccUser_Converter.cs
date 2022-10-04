using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;

namespace Business_logic_Layer.Converters
{
    public class AccUser_Converter : I_DTO_Converter<AccUser_DTO,AccUser_Model>
    {
       
        public AccUser_Model DtoToModel(AccUser_DTO dto)
        {
            AccUser_Model accuser = new AccUser_Model()
            { 
                Username = dto.Username,
                Password = dto.Password,
                Email = dto.Email,
                IsAdmin = dto.IsAdmin,
                User_ID = dto.User_ID

            };
            return accuser;
        }

       
        public AccUser_DTO ModelToDTO(AccUser_Model model)
        {
            AccUser_DTO dto = new AccUser_DTO()
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                IsAdmin = model.IsAdmin,
                User_ID = model.User_ID

            };
            return dto;
        }
    }
}
