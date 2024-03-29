﻿using Microsoft.AspNetCore.Mvc;
using Business_logic_Layer.Models;
using WebShopAsp.net_MVC_.ViewModels;
using Data_Access_Layer.Interfaces;

namespace WebShopAsp.net_MVC_.VMConverters
{
    public class User_VMC : I_ViewModel_Converter<User_Model,Login_ViewModel>
    {
        public Login_ViewModel ModelToViewModel(User_Model model)
        {
            Login_ViewModel vm = new Login_ViewModel()
            {
                
                Username = model.Username,
                Password = model.Password
            };
            return vm;
        }
        public User_Model ViewModelToModel(Login_ViewModel vm)
        {
            User_Model user_Model = new User_Model()
            {
                Username = vm.Username,
                Password = vm.Password
                
            };
            return user_Model;
        }

     
       
    }
}
