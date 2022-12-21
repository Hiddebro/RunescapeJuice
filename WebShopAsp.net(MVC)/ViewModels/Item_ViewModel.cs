using System.ComponentModel.DataAnnotations;

namespace WebShopAsp.net_MVC_.ViewModels
{
    public class Item_ViewModel
    {

        public int ItemID { get; set; }

        public string? ItemName { get; set; }
        public int Price { get; set; }
        public string Foutmelding { get; set; }

        public int Amount { get; set; }
        public int TotalItems { get; set; }
    }
}
