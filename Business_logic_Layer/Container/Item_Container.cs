using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;


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
       
        public Item_Model AddItemToUser(Item_Model item_Model, User_Model user_Model)
        {
            if (item_Model.TotalItems - item_Model.Amount >= 0) {
            Item_DTO item = new Item_DTO();
            User_DTO user = new User_DTO();
            item = converterI.ModelToDTO(item_Model);
            user = converterU.ModelToDTO(user_Model);
            item_Context.AddItemToUser(item, user);
            return converterI.DtoToModel(item);
            }
            return null;
        }

      
        public void DeleteItem(int id)
        {
           item_Context.DeleteItem(id);
        }

        public List<Item_Model> GetAllItems()
        {
            Item_Model item = new Item_Model();
            List<Item_Model> items = new List<Item_Model>();
            List<Item_DTO> DTOs = item_Context.GetAllItems();
            foreach (var dto in DTOs)
            {
                item = converterI.DtoToModel(dto);
                items.Add(item);
            }


            return items;
        }

        public List<Item_Model> GetAllUserItems(User_Model user_Model)
        {
            User_DTO user = new User_DTO();
            user = converterU.ModelToDTO(user_Model);
            Item_Model item = new Item_Model();
            List<Item_Model> userItem = new List<Item_Model>();
            List<Item_DTO> DTOs = item_Context.GetAllUserItems(user);
            foreach (var dto in DTOs)
            {
                item = converterI.DtoToModel(dto);
                userItem.Add(item);
            }
            return userItem;
        }


    }
}
