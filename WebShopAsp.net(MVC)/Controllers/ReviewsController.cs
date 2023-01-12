using Business_logic_Layer.Container;
using Business_logic_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopAsp.net_MVC_.ViewModels;
using WebShopAsp.net_MVC_.VMConverters;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;

namespace WebShopAsp.net_MVC_.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly Item_VMC viewModelConverter1 = new Item_VMC();
        private readonly Review_VMC viewModelConverter3 = new Review_VMC();
        private readonly Review_Container review_Container;
        public ReviewsController(Review_Container container)
        {
            this.review_Container = container;
        }
        public IActionResult Index(int id)
        {
            if (HttpContext.Session.GetInt32("User") > 0)
            {

                List<Review_ViewModel> reviews = new List<Review_ViewModel>();
                Item_Model item = viewModelConverter1.ViewModelToModelID(id);
                foreach (var review in review_Container.GetAllReviews(item.ItemID))
                {
                    Review_ViewModel reviewViewModel = new Review_ViewModel
                    {
                        Score = review.Score,
                        Review = review.Review,
                        ItemID = review.ItemID,
                        ReviewID = review.ReviewID
                        
                    };
                    reviews.Add(reviewViewModel);

                }
                return View(reviews);
            }
            else
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Login", "Login");
            }
        }

      

        public IActionResult ReviewItem(Review_ViewModel review_ViewModel)
        {
            if (ModelState.IsValid) { 
            if (HttpContext.Session.GetInt32("User") > 0)
            {
                Review_Model review = viewModelConverter3.ViewModelToModel(review_ViewModel);
                review_Container.AddReview(review);
                return RedirectToAction("GetAllUserItems", "User");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            }
            if (HttpContext.Session.GetInt32("User") > 0)
            {
                review_ViewModel.Melding = "Review had been added"; 
                return View("ItemReviews", review_ViewModel);
            }
            return RedirectToAction("Login", "Login");
        }

        public IActionResult GoToReviewItems(int id)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("User") > 0)
                {
                    Review_ViewModel review = new Review_ViewModel();
                    review.ItemID = id;
                    return View("ItemReviews", review);
                }
                else
                {
                    return RedirectToAction("Index", "UserItems");
                }
              
            }  return RedirectToAction("Login", "Login");
        }

        public IActionResult AddLike(int id)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("User") > 0)
                {
                   
                    int userid = (int)HttpContext.Session.GetInt32("User");
                    Review_ViewModel review = new Review_ViewModel();
                    review.ItemID = id;
                    
                   if(review_Container.AddLike(review.ItemID, userid) == true) 
                    {

                        ModelState.AddModelError(nameof(review.Foutmelding), "You have already liked this review Click anywhere to go back to the page");
                        return View(review);
                        
                    }
                    else 
                    {
                       return RedirectToAction("Index", "User");
                    }
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Login", HttpContext.Session.GetInt32("User"));
                }
            }
         
            return RedirectToAction("Login", "Login");
        }        
        
        public IActionResult ReviewLikes(int id)
         {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32("User") > 0)
                {

                    List<Review_ViewModel> reviews = new List<Review_ViewModel>();
                    foreach (var review in review_Container.GetAllLikes(id))
                    {
                        Review_ViewModel reviewViewModel = new Review_ViewModel
                        {
                            UserID = review.UserID,
                            Like = review.Like

                        };
                        reviews.Add(reviewViewModel);

                    }
                    return View(reviews);
                }
            }
            return View();
         }
    }

 

}
