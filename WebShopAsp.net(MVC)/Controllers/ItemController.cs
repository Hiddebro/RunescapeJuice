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
            return RedirectToAction("UserInfo","Account");
        }

        public IActionResult AddItem(Item_ViewModel vm)
      {
              if (ModelState.IsValid)
              {
                 Item_Model item = viewModelConverter.ViewModelToModel(vm);
                 item_Container.AddItem(item);
                // return RedirectToAction("UserInfo", "Account");
                ItemList(vm);
                return RedirectToAction("GoToAddItem","Account");
            }


            return RedirectToAction("UserInfo", "Account");
        }
      //  login_ViewModel = viewModelConverter.ModelToViewModel(user_Container.GetByName(viewModelConverter.ViewModelToModel(login_ViewModel)));
    //       public IActionResult AddItem(Item_ViewModel item_ViewModel)
    //  {
    //      if (ModelState.IsValid)
    //      {
    //          item_ViewModel = viewModelConverter.ModelToViewModel(item_Container.GetByItem(viewModelConverter.ViewModelToModel(item_ViewModel)));
    //          if(item_ViewModel != null)
    //          {
    //              return RedirectToAction("Inlog", "Account");
    //          }
    //
    //          return RedirectToAction("UserInfo", "Account");
    //      }
    //
    //      return RedirectToAction("UserInfo", "Account");
    //  }
    }
}
