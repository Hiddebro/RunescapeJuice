﻿using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using WebShopAsp.net_MVC_.ViewModels;

namespace WebShopAsp.net_MVC_.VMConverters
{
    public class User_VMC : IViewModel_Converter<User_Model, Login_ViewModel>
    {
        public Login_ViewModel ModelToViewModel(User_Model model)
        {
            Login_ViewModel vm = new Login_ViewModel()
            {
                Username = model.Username,
                Password = model.Password,
                User_ID = model.User_ID,
                IsAdmin = model.IsAdmin
            };
            return vm;
        }
        public User_Model ViewModelToModel(Login_ViewModel vm)
        {
            User_Model user_Model = new User_Model(vm.Username, vm.Password, vm.User_ID, vm.IsAdmin);
            return user_Model;
        }


    }
}
