using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer;
using Data_Access_Layer.DTOs;



namespace Data_Access_Layer.Interfaces
{
    public interface I_User_Context 
    {
        
       long Insert(User_DTO user);
        public object DubbelName(User_DTO user);
        User_DTO GetByName(User_DTO user);
        void Registrated(int id);
    }
}
