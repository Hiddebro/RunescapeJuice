using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Business_logic_Layer.Container
{
    public class User_Container
    {
        private IUser_Context user_Context;
        private readonly User_Converter converterU = new User_Converter();



        public User_Container(IUser_Context context)
        {
            this.user_Context = context;
        }

 
        public User_Model AddUser(User_Model user_Model)
        {
            User_DTO dto = converterU.ModelToDTOEmail(user_Model);
            return converterU.DtoToModel(user_Context.AddUser(dto));
        }


        public User_Model GetByName(User_Model user_Model)
        {
            User_DTO dto = converterU.ModelToDTO(user_Model);
            return converterU.DtoToModel(user_Context.GetByName(dto));
        }


    }
}
