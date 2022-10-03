using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShopAsp.net_MVC_.Models;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;
using Business_logic_Layer.Models;
using Business_logic_Layer.Container;
using Newtonsoft.Json;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class AccountController : Controller
    {
        private readonly User_VMC viewModelConverter = new User_VMC();
        private readonly User_Container user_Container;

        public AccountController(User_Container container)
        {
            this.user_Container = container;
        }

        public IActionResult Login(Login_ViewModel accountVM)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home" );
            }
            return View();
        }

        public IActionResult Register(Login_ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User_Model account = viewModelConverter.ViewModelToModel(vm);
                user_Container.Insert(account);
                return View("Login");
            }
            return RedirectToAction("Login", "Account", vm);
        }

        public ActionResult SingUp()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            return View();
        }


    }
}
