using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebShopAsp.net_MVC_.ViewModels
{
    public class Login_ViewModel
    {
        public int User_ID;
        public string Username { get; set; }
        public string Password { get; set; }
        public int Role { get; set; } 
        public int IsAdmin { get; set; }
        public int Registrated { get; set; }
        public List<Login_ViewModel> allacounts { get; set; } = new List<Login_ViewModel>();

    }
}


