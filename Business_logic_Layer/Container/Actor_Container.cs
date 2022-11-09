using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;


namespace Business_logic_Layer.Container
{
    public class Actor_Container

{
      private IActorCheck actorCheck_Context;
       private readonly User_Converter converter = new User_Converter();
     
       
       public Actor_Container(IActorCheck context)
       {
           this.actorCheck_Context = context;
       }
     
       public bool CheckActor(User_Model user_Model)
       {
           User_DTO dto = new User_DTO();
           dto = converter.ModelToDTO(user_Model);
           return actorCheck_Context.CheckActor(dto);
       }
    }
}
