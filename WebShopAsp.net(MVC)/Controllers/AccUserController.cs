using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Business_logic_Layer.Converters;


namespace WebShopAsp.net_MVC_.Controllers
{
    public class AccUserController : Controller
    {
        private readonly User_VMC viewModelConverter = new User_VMC();
        private readonly AccUserContainer accUserContainer;
        public readonly User_Container user_Container;
        public AccUserController(AccUserContainer container, User_Container accountContainer)
        {
            accUserContainer = container;
            this.user_Container = accountContainer;
        }
        public IActionResult Index()
        {
            return View();
        }
  //     public IActionResult Registration(AccUserDetail_ViewModel vm)
  //     {
  //         if (HttpContext.Session.GetInt32("User") != null)
  //         {
  //             Login_ViewModel account = new Login_ViewModel();
  //             account = JsonConvert.DeserializeObject<Login_ViewModel>(HttpContext.Session.GetString("User"));
  //             if (ModelState.IsValid && account.Role == 0)
  //             {
  //                 vm.User_ID = account.User_ID;
  //                 AccUser_Model accuser = viewModelConverter.ViewModelToModel(vm);
  //                 accUserContainer.Insert(accuser);
  //                 user_Container.Registrated(account.User_ID);
  //                 account.Registrated = 1;
  //                 HttpContext.Session.SetString("User", JsonConvert.SerializeObject(account));
  //                 return RedirectToAction("Profile", "AccUser");
  //             }
  //         }
  //         return RedirectToAction("Login", "Account");
  //     }
    }
}
