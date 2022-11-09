namespace WebShopAsp.net_MVC_.ViewModels
{
    public class Item_ViewModel
    {
        public int User_ID { get; set; }
        public int IsAdmin { get; set; }
        public int ItemID { get; set; }
        public string? ItemName { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
       // public List<Item_ViewModel> allitems { get; set; } = new List<Item_ViewModel>();

        public Item_ViewModel()
        {

        }
    }
}
