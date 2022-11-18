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
        private readonly Item_VMC viewModelConverter = new Item_VMC();
        private readonly Item_Container item_Container;



        public UserController(Item_Container container)
        {
            this.item_Container = container;
        }


        public IActionResult Index(Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0 & login_ViewModel.IsAdmin == 0) { 
            List<Item_ViewModel> items = new List<Item_ViewModel>();
            foreach (var item in item_Container.GetAllItems())
            {
                Item_ViewModel itemViewModel = new Item_ViewModel
                {
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    Price = item.Price,
                    Amount = item.Amount
                };
                items.Add(itemViewModel);

            }
            return View(items);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }

    //    public IActionResult GoToUserMainPage(Login_ViewModel login_ViewModel)
    //    {
    //        if (HttpContext.Session.GetInt32("User") > 0 & login_ViewModel.IsAdmin == 0)
    //        {
    //            return View("UserMainPage", login_ViewModel);
    //        }
    //        else
    //        {
    //            HttpContext.Session.Clear();
    //            return RedirectToAction("Login", "Login");
    //        }
    //    }
        
        }

        public IActionResult BuyItem()
        {
            return RedirectToAction("Index","User");
        }

        public IActionResult ReviewItem()
        {
            return RedirectToAction("Index","User");
        }


    }
}
