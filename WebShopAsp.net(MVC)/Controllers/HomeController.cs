using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebShopAsp.net_MVC_.Models;
using Business_logic_Layer.Models;
using Data_Access_Layer.Context;
using Business_logic_Layer.Converters;
using Newtonsoft.Json;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

           
            return RedirectToAction("Privacy", "Home");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}