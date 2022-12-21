using Business_logic_Layer.Container;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class EmailController : Controller
    {

        private readonly Email_Container email_Container;

        public EmailController(Email_Container container)
        {
            this.email_Container = container;
        }
        public IActionResult SendEmail(Login_ViewModel vm)
        {
            email_Container.SendEmail(vm.Email);
            return RedirectToAction("Login", "Login");
        }
    }
}
