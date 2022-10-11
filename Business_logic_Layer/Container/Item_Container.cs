using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_logic_Layer.Converters;
using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Interfaces;


namespace Business_logic_Layer.Container
{
    public class Item_Container
    {
        private I_Item_Context item_Context;
        private readonly Item_Converter converter = new Item_Converter();
        public Item_Container(I_Item_Context context)
        {
            this.item_Context = context;
        }
        public long AddItem(Item_Model item_Model)
     {
         Item_DTO dto = new Item_DTO();
         dto = converter.ModelToDTO(item_Model);
         return item_Context.AddItem(dto);
     }

  //     public Item_Model GetByItem(Item_Model item_Model)
  //     {
  //         Item_DTO dto = new Item_DTO();
  //         dto = converter.ModelToDTO(item_Model);
  //         return converter.DtoToModel(item_Context.GetByItem(dto));
  //     }
    }
}
