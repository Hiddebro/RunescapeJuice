using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Interfaces
{
    public interface IItem_Context
    {
        public Item_DTO AddItem(Item_DTO item);
        public List<Item_DTO> GetAllItems();
        public void DeleteItem(int id);
        public Item_DTO AddItemToUser(Item_DTO item, User_DTO user);
        public List<Item_DTO> GetAllUserItems(User_DTO user);
        public bool CheckIfOwned(int item, int user);
        public void SellItem(int id, int userID, int amount);
        public Item_DTO DoubleItems(Item_DTO item, User_DTO user);
        public void SendEmail();
        public Item_DTO GetItemAmountByID(Item_DTO item);


        //   public Item_DTO GetByItem(Item_DTO dto);
    }
}
