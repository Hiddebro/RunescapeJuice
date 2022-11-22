using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;


namespace Business_logic_Layer.Container
{
    public class User_Container
    {
        private IUser_Context user_Context;
        private readonly User_Converter converterU = new User_Converter();
        private readonly Item_Converter converterI = new Item_Converter();



        public User_Container(IUser_Context context)
        {
            this.user_Context = context;
        }


        public bool CheckActorr(User_Model user_Model)
        {
            User_DTO dto = new User_DTO();
            dto = converterU.ModelToDTO(user_Model);
            return  user_Context.CheckActorr(dto);
        }

       
        public User_Model AddUser(User_Model user_Model)
        {
            User_DTO dto = new User_DTO();
            dto = converterU.ModelToDTO(user_Model);
            return converterU.DtoToModel(user_Context.AddUser(dto));
        }


        public User_Model GetByName(User_Model user_Model)
        {
            User_DTO dto = new User_DTO();
            dto = converterU.ModelToDTO(user_Model);
            
            return converterU.DtoToModel(user_Context.GetByName(dto));
        }
        


        public User_Model GetByIsAdmin(User_Model user_Model)
        {
            User_DTO dto = new User_DTO();
            dto = converterU.ModelToDTO(user_Model);
            return converterU.DtoToModel(user_Context.GetByIsAdmin(dto));
        }

      

    }
}
