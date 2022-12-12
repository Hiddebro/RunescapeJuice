using System.ComponentModel.DataAnnotations;

namespace WebShopAsp.net_MVC_.ViewModels
{
    public class Review_ViewModel
    {

        public int ItemID { get; set; }
        public string Review { get; set; }
        [Range(1, 10)]
        public int Score { get; set; }

    }
}
