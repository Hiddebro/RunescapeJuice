namespace Business_logic_Layer.Models
{
    public class Item_Model
    {
        public int ItemID { get; set; }
        public string? ItemName { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int TotalItems { get; set; }

        public Item_Model(int itemID, string itemName, int price, int amount, int totalItems)
        {
            ItemID = itemID;
            ItemName = itemName;
            Price = price;
            Amount = amount;
            TotalItems = totalItems;
        }


        public Item_Model(int itemID, string itemName, int price, int amount)
        {
            ItemID = itemID;
            ItemName = itemName;
            Price = price;
            Amount = amount;
        }

        public Item_Model()
        {

        }

    }
}
