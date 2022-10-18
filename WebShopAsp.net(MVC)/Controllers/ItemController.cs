using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;

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


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllItems(Item_ViewModel vm)
        {
            Item_Model item = viewModelConverter.ViewModelToModel(vm);
            item_Container.GetAllItems(item);
            return View();
        }

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
