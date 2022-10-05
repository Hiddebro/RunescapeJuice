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

        

        public IActionResult Login(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            {
                login_ViewModel = viewModelConverter.ModelToViewModel(user_Container.GetByName(viewModelConverter.ViewModelToModel(login_ViewModel)));

                if (login_ViewModel.User_ID != 0)
                {
                    return View("UserInfo");
                }
              return View();
            }
                
            return View();
        }

        public IActionResult GoToRegister(Login_ViewModel login_ViewModel)
        {
            if (ModelState.IsValid)
            { 
            return View();
            }
            return View("Register");
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
                   user_Container.Insert(user);
                   return View("Login");
               }
            return View("Register");
        }
  //      public IActionResult Register(Login_ViewModel vm)
  //      {
  //          User_Model user = viewModelConverter.ViewModelToModel(vm);
  //          if (ModelState.IsValid)
  //          {
  //
  //              user_Container.DubbelName(user);
  //              return View("Register");
  //          }
  //          if (user != null)
  //          {
  //
  //              user_Container.Insert(user);
  //              return View("Login");
  //          }
  //          return View("Register");
  //      }

        public ActionResult SingUp()
        {
            return View();
        }

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword
        public ActionResult SignOut()
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
        {
            return View();
        }


    }
}

