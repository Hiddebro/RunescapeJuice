using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoToAdminMainPage(Login_ViewModel login_ViewModel)
        {
            return View("AdminMainPage");
        }

        public IActionResult GoToAddItem(Login_ViewModel login_Viewmodel)
        {
            return View("AddItem");
        }
    }
}
