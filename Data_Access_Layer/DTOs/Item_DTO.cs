using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.DTOs
{
    public class Item_DTO
    {

        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Price { get; set; }
        public int Amount { get; set; }
        public int TotalItems { get; set; }


        public Item_DTO(int itemID, string itemName, int price, int amount, int totalItems)
        {
            ItemID = itemID;
            ItemName = itemName;
            Price = price;
            Amount = amount;
            TotalItems = totalItems;
        }

        public Item_DTO()
        {

        }
    }
}
