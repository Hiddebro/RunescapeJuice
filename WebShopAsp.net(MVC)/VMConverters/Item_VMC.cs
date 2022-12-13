using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using WebShopAsp.net_MVC_.ViewModels;

namespace WebShopAsp.net_MVC_.VMConverters
{
    public class Item_VMC : IViewModel_Converter<Item_Model, Item_ViewModel>
    {

        public Item_ViewModel ModelToViewModel(Item_Model model)
        {
            Item_ViewModel vm = new Item_ViewModel()
            {
                ItemID = model.ItemID,
                ItemName = model.ItemName,
                Price = model.Price,
                Amount = model.Amount
            };
            return vm;
        }
        public Item_Model ViewModelToModel(Item_ViewModel vm)
        {
            Item_Model item_Model = new Item_Model(vm.ItemID, vm.ItemName, vm.Price, vm.Amount);
            return item_Model;
        }

        public Item_Model ViewModelToModelID(int id)    
        {
            Item_Model item_Model = new Item_Model(id);
            return item_Model;
        }

        public Item_Model ViewModelToModelA(Item_ViewModel vm)
        {
            Item_Model item_Model = new Item_Model(vm.ItemID, vm.ItemName, vm.Price, vm.Amount, vm.TotalItems);
            return item_Model;
        }
    }
}



