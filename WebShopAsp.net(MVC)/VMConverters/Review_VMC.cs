using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using WebShopAsp.net_MVC_.ViewModels;

namespace WebShopAsp.net_MVC_.VMConverters
{
    public class Review_VMC : IViewModel_Converter<Review_Model, Review_ViewModel>
    {
        public Review_ViewModel ModelToViewModel(Review_Model model)
        {
            Review_ViewModel vm = new Review_ViewModel()
            {
                ItemID = model.ItemID,
                Review = model.Review,
                Score = model.Score

            };
            return vm;
        }

        public Review_Model ViewModelToModel(Review_ViewModel vm)
        {
            Review_Model review_Model = new Review_Model(vm.ItemID,vm.Review,vm.Score);
            return review_Model;
        }
    }
}
