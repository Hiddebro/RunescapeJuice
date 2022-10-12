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

        public static List<String> Item_Model;
        public ActionResult ItemList(Item_ViewModel vm)
        {
            var model = new List<String>();
            model.Add(item_Container.ToString());
            return View(model);
        }
        public IActionResult BackToUserInfo()
        {
            return RedirectToAction("UserInfo", "User");
        }

        public IActionResult AddItem(Item_ViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Item_Model item = viewModelConverter.ViewModelToModel(vm);
                item_Container.AddItem(item);

                ItemList(vm);
                return RedirectToAction("GoToAddItem", "User");
            }


            return RedirectToAction("GoToUserInfo", "User");
        }

    }
}
