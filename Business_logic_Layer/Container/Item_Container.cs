using Business_logic_Layer.Converters;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;


namespace Business_logic_Layer.Container
{
    public class Item_Container
    {
        private IItem_Context item_Context;
        private readonly Item_Converter converter = new Item_Converter();
        public Item_Container(IItem_Context context)
        {
            this.item_Context = context;
        }
        public Item_Model AddItem(Item_Model item_Model)
        {
            Item_DTO dto = new Item_DTO();
            dto = converter.ModelToDTO(item_Model);
            return converter.DtoToModel(item_Context.AddItem(dto));
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
                item = converter.DtoToModel(dto);
                items.Add(item);
            }


            return items;
        }



    }
}
