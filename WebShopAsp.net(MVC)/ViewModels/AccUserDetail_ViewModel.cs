
namespace WebShopAsp.net_MVC_.ViewModels
{
    public class AccUserDetail_ViewModel
    {
        public int User_ID { get; set; }
        public string Username { get; set; } = string.Empty;      
        public string Password { get; set; } = string.Empty;
        public int IsAdmin { get; set; }
        public int Registrated { get; set; }

    }
}
