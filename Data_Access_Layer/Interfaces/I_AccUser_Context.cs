using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Interfaces
{
    public interface I_AccUser_Context 
    {
        long Insert(AccUser_DTO accuser);
        public long Update(AccUser_DTO accuser);
    }
}
