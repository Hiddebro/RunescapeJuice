using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;

namespace UnitTests.Mock
{
    
    public class MockUserData : I_User_Context
    {
        List<string> _users = new List<string>();
        
            
       
        public User_DTO GetByName(User_DTO user)
        {
            throw new NotImplementedException();
        }

        public long Insert(User_DTO user)
        {
            throw new NotImplementedException();
        }

        public void Registrated(int id)
        {
            throw new NotImplementedException();
        }
    }
}
