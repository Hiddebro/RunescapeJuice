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

        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoToAdminMainPage(Login_ViewModel login_ViewModel, User_Model user_Model)
        {
          //  var SessionAdmin = HttpContext.Session.GetInt32("Admin");
            var SessionUser = HttpContext.Session.GetInt32("User");
            user_Container.CheckActorr(user_Model);
            if (true)
            {
                return View("AdminMainPage" , login_ViewModel);
            }else if (false)
            {
                return View();
            }
            return View();
        }

        public IActionResult GoToAddItem(Login_ViewModel login_ViewModel , Item_ViewModel item_ViewModel)
        {
            var SessionUser = HttpContext.Session.GetInt32("User");
         //  if (login_ViewModel.IsAdmin == 1)
         //  { 
         //      return View("AddItem");
         //  }
            return View("AddItem");
        }
    }
}
