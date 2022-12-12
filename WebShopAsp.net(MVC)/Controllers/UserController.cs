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
        private readonly User_VMC viewModelConverter2 = new User_VMC();
        private readonly Item_VMC viewModelConverter1 = new Item_VMC();
        private readonly Review_VMC viewModelConverter3 = new Review_VMC();
        private readonly Item_Container item_Container;
        int ItemsBuying;
        public UserController(Item_Container container)
        {
            this.item_Container = container;
        }

        public IActionResult Index(Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0 & login_ViewModel.IsAdmin == 0)
            {
                List<Item_ViewModel> items = new List<Item_ViewModel>();
                foreach (var item in item_Container.GetAllItems())
                {
                    Item_ViewModel itemViewModel = new Item_ViewModel
                    {
                        ItemID = item.ItemID,
                        ItemName = item.ItemName,
                        Price = item.Price,
                        Amount = item.Amount,
                    };
                    items.Add(itemViewModel);
                }
                return View(items);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
        public IActionResult BuyItem(Item_ViewModel item_ViewModel, Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0)
            {
                
                Item_Model item = viewModelConverter1.ViewModelToModelA(item_ViewModel);
                User_Model user = viewModelConverter2.ViewModelToModel(login_ViewModel);
                item = item_Container.GetItemAmountByID(item);
                user.User_ID = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                if (item.TotalItems >= item.Amount)
                {
                if (item_Container.CheckIfOwned(item.ItemID, user.User_ID) == true)
                {
                    item_Container.DoubleItems(item, user);
                }
                else
                {
                    item_Container.AddItemToUser(item, user);
                }
                return RedirectToAction("Index", "User");
                }
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult GetAllUserItems(Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0 & login_ViewModel.IsAdmin == 0)
            {
                List<Item_ViewModel> items = new List<Item_ViewModel>();
                User_Model user = viewModelConverter2.ViewModelToModel(login_ViewModel);
                user.User_ID = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                foreach (var item in item_Container.GetAllUserItems(user))
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
                return View("UserItems", items);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult SellItem(Item_ViewModel item_Viewmodel, Login_ViewModel login_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0)
            {

                User_Model user = viewModelConverter2.ViewModelToModel(login_ViewModel);
                user.User_ID = Convert.ToInt32(HttpContext.Session.GetInt32("User"));
                Item_Model item = viewModelConverter1.ViewModelToModelA(item_Viewmodel);
                item_Container.SellItem(item.ItemID, user.User_ID, item.Amount);
                return RedirectToAction("GetAllUserItems");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }
    }
}
