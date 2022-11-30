using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class AdminController : Controller
    {

        private readonly User_VMC viewModelConverter = new User_VMC();
        private readonly User_Container user_Container;
        
    

        public AdminController(User_Container container)
        {
            this.user_Container = container;
        }

        
        public IActionResult Index(Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("Admin") > 0)
            {
                return View(login_ViewModel);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }

        
    }
}
