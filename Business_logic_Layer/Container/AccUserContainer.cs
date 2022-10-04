using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.Interfaces;
using Data_Access_Layer.DTOs;
using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;

namespace Business_logic_Layer.Container
{
    public class AccUserContainer
    {
        protected readonly I_AccUser_Context context;
        private readonly AccUser_Converter converter = new AccUser_Converter();

        public AccUserContainer(I_AccUser_Context context)
        {
            this.context = context;
        }
        
  //   public AccUser_Model GetById(int id)
  //   {
  //       AccUser_Model accuser = new AccUser_Model();
  //       AccUser_DTO dto = context.GetById(id);
  //       accuser = converter.DtoToModel(dto);
  //       return accuser;
  //   }
        
        public long Insert(AccUser_Model accuser)
        {
            AccUser_DTO dto = new AccUser_DTO();
            dto = converter.ModelToDTO(accuser);
            return context.Insert(dto);
        }
      
      
       
        public long Update(AccUser_Model accuser)
        {
           AccUser_DTO dto = new AccUser_DTO();
            dto = converter.ModelToDTO(accuser);
            return context.Update(dto);
        }
    }
}
