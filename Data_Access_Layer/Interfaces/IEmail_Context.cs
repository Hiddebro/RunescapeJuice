using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Interfaces
{
     public interface IEmail_Context
    {
        public bool SendEmail(string email);
    }
}
