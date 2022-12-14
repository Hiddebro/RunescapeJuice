using System.ComponentModel.DataAnnotations;

namespace WebShopAsp.net_MVC_.ViewModels
{
    public class Review_ViewModel
    {

        public int ItemID { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Een review is tussen de 20 en 1000 characters")]
        public string Review { get; set; }
        [Required]
        [Range(1, 10, ErrorMessage ="Score is tussen de 1 en 10")]
        public int Score { get; set; }

        public int ReviewID { get; set; }

    }
}
