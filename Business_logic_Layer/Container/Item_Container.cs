﻿using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;
using System.Net;
using System.Net.Mail;

namespace Business_logic_Layer.Container
{
    public class Item_Container
    {
        private IItem_Context item_Context;
        private readonly Item_Converter converterI = new Item_Converter();
        private readonly User_Converter converterU = new User_Converter();

        public Item_Container(IItem_Context context)
        {
            this.item_Context = context;
        }
        public Item_Model AddItem(Item_Model item_Model)
        {
            Item_DTO dto = converterI.ModelToDTO(item_Model);
            return converterI.DtoToModel(item_Context.AddItem(dto));
        }

        public Item_Model AddItemToUser(Item_Model item_Model, User_Model user_Model, int amount)
        {
            if (item_Model.TotalItems - amount >= 0)
            {
                Item_DTO item = converterI.ModelToDTO(item_Model);
                User_DTO user = converterU.ModelToDTO(user_Model);
                item_Context.AddItemToUser(item, user,amount);
                return converterI.DtoToModel(item);
            }
            return item_Model;
        }

        public Item_Model DoubleItems(Item_Model item_Model, User_Model user_Model, int Amount)
        {
            if (item_Model.TotalItems - Amount >= 0)
            {
                Item_DTO item = converterI.ModelToDTO(item_Model);
                User_DTO user = converterU.ModelToDTO(user_Model);
                item_Context.DoubleItems(item, user, Amount);
                return converterI.DtoToModel(item);
            }
            return item_Model;
        }


        public List<Item_Model> GetAllUserItems(User_Model user_Model)
        {
            User_DTO user = converterU.ModelToDTO(user_Model);
            Item_Model item;
            List<Item_Model> userItem = new List<Item_Model>();
            List<Item_DTO> DTOs = item_Context.GetAllUserItems(user);
            foreach (var dto in DTOs)
            {
                item = converterI.DtoToModel(dto);
                userItem.Add(item);
            }
            return userItem;
        }

        public List<Item_Model> GetAllItems()
        {
            Item_Model item;
            List<Item_Model> items = new List<Item_Model>();
            List<Item_DTO> DTOs = item_Context.GetAllItems();
            foreach (var dto in DTOs)
            {
                item = converterI.DtoToModel(dto);
                items.Add(item);
            }
            return items;
        }


        public Item_Model GetItemData(int itemid)
        {
            Item_DTO item = converterI.ModelToDTOId(itemid);
            item = item_Context.GetItemData(item);
            return converterI.DtoToModel(item);
        }


        public void DeleteItem(int id)
        {
            item_Context.DeleteItem(id);
        }

        public void SellItem(int id, int userID, int amount)
        {
            item_Context.SellItem(id, userID, amount);
        }

        public bool CheckIfOwned(int item, int user)
        {
            return item_Context.CheckIfOwned(item, user);
        }

       
     
    }
}