using Microsoft.AspNetCore.Mvc;
using Business_logic_Layer.Models;
using WebShopAsp.net_MVC_.ViewModels;
using Data_Access_Layer.Interfaces;

namespace WebShopAsp.net_MVC_.VMConverters
{ 
    public class Item_VMC : I_ViewModel_Converter<Item_Model, Item_ViewModel>
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
        Item_Model item_Model = new Item_Model()
        {
            ItemID = vm.ItemID,
            ItemName = vm.ItemName,
            Price = vm.Price,
            Amount = vm.Amount


        };
        return item_Model;
    }
   }
}
  


