using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class UserController : Controller
    {
        private readonly User_VMC viewModelConverter = new User_VMC();
        private readonly User_Container user_Container;

        public UserController(User_Container container)
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
                    return RedirectToAction("GoToUserMainPage", "User");
                }
                else if (login_ViewModel.User_ID != 0 & login_ViewModel.IsAdmin == 1)
                {
                    return RedirectToAction("GoToAdminMainPage", "User");
                }
                return View();
            }

            return View();
        }

        public IActionResult GoToUserMainPage(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("UserMainPage");
        }

        public IActionResult GoToAdminMainPage(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("AdminMainPage");
        }
        public IActionResult GoToUserInfo(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("UserInfo");
        }

        public IActionResult GoToRegister(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("Register");
        }

        public IActionResult GoToAddItem(Login_ViewModel login_Viewmodel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("AddItem");
        }
        public IActionResult GoToLogin(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return View("Login");
        }

        public IActionResult Register(Login_ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                User_Model user = viewModelConverter.ViewModelToModel(vm);
                user_Container.AddUser(user);
                return View("Login");
            }
            return View("Register");
        }


        public ActionResult SingUp()
        {
            return View();
        }





    }
}

