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
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly User_VMC viewModelConverter = new User_VMC();
        private readonly User_Container user_Container;

        public LoginController(User_Container container)
        {
            this.user_Container = container;
        }



        public IActionResult Login(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                login_ViewModel = viewModelConverter.ModelToViewModel(user_Container.GetByName(viewModelConverter.ViewModelToModel(login_ViewModel)));
                if (login_ViewModel.User_ID != 0 & login_ViewModel.IsAdmin == 0)
                {

                    HttpContext.Session.SetInt32("User", login_ViewModel.User_ID);
                    return RedirectToAction("GoToUserMainPage", "User", login_ViewModel);

                }
                else if (login_ViewModel.User_ID != 0 & login_ViewModel.IsAdmin == 1)
                {
                    HttpContext.Session.SetInt32("User", login_ViewModel.User_ID);

                    return RedirectToAction("GoToAdminMainPage", "Admin", login_ViewModel);
                }
                return View();
            }

            return View();
        }

        public IActionResult AddUser(Login_ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User_Model user = viewModelConverter.ViewModelToModel(vm);
                user_Container.AddUser(user);
                return View("Login");
            }
            return View("Register");
        }

        public IActionResult GoToRegister(Login_ViewModel login_ViewModel)
        {
            return View("Register");
        }
    }
}
