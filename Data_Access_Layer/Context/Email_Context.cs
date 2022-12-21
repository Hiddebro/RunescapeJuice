using Data_Access_Layer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Context
{
    public class Email_Context : IEmail_Context
    {
        public bool SendEmail(string email)
        {
            string outlookAddress = "TestSCHH@outlook.com";
            string outlookPassword = "HenkHenk123";
             try
            {

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress(outlookAddress);
            message.To.Add(new MailAddress(email));
            message.Subject = "RS GOLD - Koop NU";
            message.IsBodyHtml = true;
            message.Body =
                $"<div><h3>Bedankt voor het registreren</h3></div>" +
                $"<div><p> Ik hoop dat dit een goede ervaring wordt geniet van de site. </p> </div>";

            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(outlookAddress, outlookPassword); // CREDENTIALS
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

           
                smtp.Send(message);
            }
            catch { };
            return true;
        }
    }
}
