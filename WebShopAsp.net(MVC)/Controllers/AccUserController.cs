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
  //     private readonly User_VMC viewModelConverter = new User_VMC();
  //     private readonly AccUserContainer accUserContainer;
  //     public readonly User_Container user_Container;
  //     public AccUserController(AccUserContainer container, User_Container accountContainer)
  //     {
  //         accUserContainer = container;
  //         this.user_Container = accountContainer;
  //     }
        public IActionResult Index()
        {
            return View();
        }
  
    }
}
