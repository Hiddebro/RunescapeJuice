using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Interfaces
{
    public interface IActorCheck
    {
        public bool CheckActor(User_DTO user);
    }
}
