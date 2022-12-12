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
        public List<Item_DTO> items = new List<Item_DTO>();
        public List<Item_DTO> Useritems = new List<Item_DTO>();
        public List<Item_DTO> doubleItems = new List<Item_DTO>();
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
            items.Add(item);
            return item;
        }
        public List<Item_DTO> GetAllItems()
        {
            return items;
        }
        public void DeleteItem(int id)
        {
            GetAllItems().RemoveAt(id);
        }

        public Item_DTO AddItemToUser(Item_DTO item, User_DTO user)
        {
            items.Add(item);
            return item;
        }
        public List<Item_DTO> GetAllUserItems(User_DTO user)
        {
            return items;
        }

        public void SellItem(int id, int userID, int amount)
        {
            GetAllItems().RemoveAt(id);
        }

        public Item_DTO DoubleItems(Item_DTO item, User_DTO user)
        {
            Item_DTO item1 = new Item_DTO();
            item1.ItemID = 1;
            item1.ItemName = "SGS";
            item1.Amount = 50;
            item1.Price = 100000;

            if (item1.ItemName == item.ItemName)
            {
                return item1;

            }
            else if (item1.ItemName != item.ItemName)
            {
                return item;
            }
            return item1;
        }

        public bool CheckIfOwned(int item, int user)
        {
            Item_DTO item1 = new Item_DTO();
            item1.ItemID = 1;
            item1.ItemName = "SGS";
            item1.Amount = 50;
            item1.Price = 100000;
            if (item1.ItemID == item)
            {
                return true;
            }
            return false;
        }
        public void SendEmail()
        {

        }

        public Item_DTO GetItemAmountByID(Item_DTO item)
        {
            return null;
        }
    }
}

