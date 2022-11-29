﻿using Business_logic_Layer.Container;
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
        public IActionResult Index(Item_ViewModel item_ViewModel, Review_ViewModel review_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0)
            {
                List<Review_ViewModel> reviews = new List<Review_ViewModel>();
                Item_Model item = viewModelConverter1.ViewModelToModel(item_ViewModel);
                foreach (var review in review_Container.GetAllReviews(item.ItemID))
                {
                    Review_ViewModel reviewViewModel = new Review_ViewModel
                    {
                        Score = review.Score,
                        Review = review.Review,
                        ItemID = review.ItemID
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

      //  public IActionResult GetAllReviews(Review_ViewModel review_ViewModel, Item_ViewModel item_ViewModel)
     //   {
     // //  }

        public IActionResult ReviewItem(Review_ViewModel review_ViewModel, Item_ViewModel item_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0)
            {
                Review_Model review = viewModelConverter3.ViewModelToModel(review_ViewModel);
                review_Container.AddReview(review);
                return RedirectToAction("GetAllUserItems", "User");
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        public IActionResult GoToReviewItems(Review_ViewModel review_ViewModel, Item_ViewModel item_ViewModel)
        {
            if (HttpContext.Session.GetInt32("User") > 0)
            {
                review_ViewModel.ItemID = item_ViewModel.ItemID;
                return View("ItemReviews", review_ViewModel);
            }

            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}