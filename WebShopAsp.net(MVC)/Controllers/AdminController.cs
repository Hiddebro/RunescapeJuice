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
        
        protected void Page_load(object sender, EventArgs e)
        {
            HttpContext.Session.GetInt32("User");
        }

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
            if (HttpContext.Session.GetInt32("Admin") > 0)
            { 
                return View("AdminMainPage" , login_ViewModel);
                
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult GoToAddItem(Login_ViewModel login_ViewModel, Item_ViewModel item_ViewModel)
        {
            
            if (HttpContext.Session.GetInt32("Admin") > 0)
            {
                return View("AddItem", item_ViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
    }
}
