using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;
using Microsoft.AspNetCore.Http;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class ItemController : Controller
    {
        private readonly Item_VMC viewModelConverter = new Item_VMC();
        private readonly Item_Container item_Container;



        public ItemController(Item_Container container)
        {
            this.item_Container = container;
        }

        [HttpGet]
        public IActionResult Index()
        {
          //  item_Container.SendRegistrationMail();
            List<Item_ViewModel> items = new List<Item_ViewModel>();
            if (HttpContext.Session.GetInt32("Admin") > 0)
            { 
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
                return RedirectToAction("Login", "Login");
            }

        }

        public IActionResult AddItem(Item_ViewModel vm)
        {
            if (HttpContext.Session.GetInt32("Admin") > 0)

            {
                Item_Model item = viewModelConverter.ViewModelToModel(vm);
                item_Container.AddItem(item);
                return RedirectToAction("GoToAdmin", "User");
            }
            return View();
        }



        public IActionResult DeleteItem(int ItemID)
        {
            if (HttpContext.Session.GetInt32("Admin") > 0)
            {
                item_Container.DeleteItem(ItemID);
                return RedirectToAction("Index", "Item");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        public IActionResult GoToAddItem(Item_ViewModel item_ViewModel)
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

        public IActionResult GoToBuyItems(Item_ViewModel item_ViewModel)
        {

            if (HttpContext.Session.GetInt32("User") > 0)
            {
                return View("BuyItems", item_ViewModel);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

        }





    }
}


