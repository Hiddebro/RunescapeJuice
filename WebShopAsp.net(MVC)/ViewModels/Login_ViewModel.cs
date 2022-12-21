using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebShopAsp.net_MVC_.ViewModels
{
    public class Login_ViewModel
    {
        public int User_ID { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username is tussen de 3 en de 15 characters")]

        public string Username { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 3 , ErrorMessage = "Password is tussen de 3 en de 15 characters")]
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public string? Email { get; set; }   

    }
}


