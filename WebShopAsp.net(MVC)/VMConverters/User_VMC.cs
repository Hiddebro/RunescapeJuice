using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using WebShopAsp.net_MVC_.ViewModels;

namespace WebShopAsp.net_MVC_.VMConverters
{
    public class User_VMC 
    {
        public Login_ViewModel ModelToViewModel(User_Model model)
        {
            Login_ViewModel vm = new Login_ViewModel()
            {
                Username = model.Username,
                Password = model.Password,
                User_ID = model.User_ID,
                IsAdmin = model.IsAdmin,
                Email = model.Email
            };
            return vm;
        }
        public User_Model ViewModelToModel(Login_ViewModel vm)
        {
            User_Model user_Model = new User_Model(vm.User_ID, vm.IsAdmin, vm.Username, vm.Password);
            return user_Model;
        }

        public User_Model ViewModelToModelEmail(Login_ViewModel vm)
        {
            User_Model user_Model = new User_Model(vm.User_ID, vm.IsAdmin, vm.Username, vm.Password, vm.Email);
            return user_Model;
        }


    }
}
