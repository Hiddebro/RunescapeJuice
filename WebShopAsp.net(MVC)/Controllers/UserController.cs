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
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoToUserMainPage(Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0 & login_ViewModel.IsAdmin == 0)
            {
                return View("UserMainPage", login_ViewModel);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
           
        }
    }
}
