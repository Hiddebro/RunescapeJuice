namespace WebShopAsp.net_MVC_.VMConverters;
using WebShopAsp.net_MVC_.ViewModels;
using Business_logic_Layer.Models;


    public class Account_VMC
    {

    public AccUser_Model ViewModelToModel(AccUserDetail_ViewModel vmodel)
        {
            AccUser_Model m = new AccUser_Model()
            {
                Username = vmodel.Username,
                Password = vmodel.Password

            };
            return m;
        }
   
        
        public AccUserDetail_ViewModel ModelToViewModel(AccUser_Model model)
        {
            AccUserDetail_ViewModel vm = new AccUserDetail_ViewModel()
            {
                
                Username = model.Username,
                Password = model.Password
              
            };
            return vm;
        }
    }

