using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Data_Access_Layer.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace Business_logic_Layer.Container
{
    public class Email_Container
    {
        private IEmail_Context Email_Context;
        public Email_Container(IEmail_Context context)
        {
            this.Email_Context = context;
        }
        public bool SendEmail(string email)
        {
          Email_Context.SendEmail(email);
           return true;
        }
    }
}
