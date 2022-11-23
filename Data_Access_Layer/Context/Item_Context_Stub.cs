using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Context
{
    public class Item_Context_Stub : IItem_Context
    {
        public static List<Item_DTO> items = new List<Item_DTO>();
        Item_DTO item = new Item_DTO();

        public Item_Context_Stub()
        {
            Item_DTO item = new Item_DTO();
            item.ItemID = 1;
            item.ItemName = "SGS";
            item.Amount = 50;
            item.Price = 100000;
            items.Add(item);

            Item_DTO item1 = new Item_DTO();
            item.ItemID = 2;
            item.ItemName = "SGS";
            item.Amount = 500;
            item.Price = 1000000;
            items.Add(item1);

            Item_DTO item2 = new Item_DTO();
            item.ItemID = 3;
            item.ItemName = "SGS";
            item.Amount = 5000;
            item.Price = 10000000;
            items.Add(item2);

            Item_DTO item3 = new Item_DTO();
            item.ItemID = 4;
            item.ItemName = "SGS";
            item.Amount = 50;
            item.Price = 100000;
            items.Add(item3);
        }

        public Item_DTO AddItem(Item_DTO item)
        {
            return item;
        }

        public void DeleteItem(int id)
        {

        }
        public List<Item_DTO> GetAllItems()
        {
            return items;
        }
        public Item_DTO AddItemToUser(Item_DTO item, User_DTO user)
        {
            return null;
        }
        public List<Item_DTO> GetAllUserItems(User_DTO user)
        {
            return null;
        }

        public void SellItem(int id, int userID, int amount)
        {

        }

        public Item_DTO DoubleItems(Item_DTO item, User_DTO user)
        {
            return null;
        }

        public bool CheckIfOwned(int item, int user)
        {
            return true;
        }
    }
}

