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
        
     //  public IActionResult GetAllItems()
     //  {
     //      List<Item_ViewModel> items = new List<Item_ViewModel>();
     //      foreach(var item in item_Container.GetAllItems())
     //      {
     //          Item_ViewModel itemViewModel = new Item_ViewModel
     //          {
     //              ItemID = item.ItemID,
     //              ItemName = item.ItemName,
     //              Price = item.Price,
     //              Amount = item.Amount
     //          };
     //          items.Add(itemViewModel);
     //
     //      }
     //      return RedirectToAction("GoToAdminMainPage", "Admin");
     //  }

        public IActionResult AddItem(Item_ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Item_Model item = viewModelConverter.ViewModelToModel(vm);
                item_Container.AddItem(item);
                return RedirectToAction("GoToAdminMainPage","Admin");
            }
            return View();
        }

    }
}
