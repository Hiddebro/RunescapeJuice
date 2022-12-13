using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;

namespace Business_logic_Layer.Converters
{
    public class Item_Converter
    {
        public Item_Model DtoToModel(Item_DTO dto)
        {
            Item_Model item_Model = new Item_Model(dto.ItemID, dto.ItemName, dto.Price, dto.Amount, dto.TotalItems);
            return item_Model;
        }

        public Item_DTO ModelToDTO(Item_Model model)
        {
            Item_DTO dto = new Item_DTO()
            {
                ItemID = model.ItemID,
                ItemName = model.ItemName,
                Price = model.Price,
                Amount = model.Amount,
                TotalItems = model.TotalItems
                
            };
            return dto;
        }

        public Item_DTO ModelToDTOId(int itemid)
        {
            Item_DTO dto = new Item_DTO()
            {
                ItemID = itemid

            };
            return dto;
        }

    }
}
