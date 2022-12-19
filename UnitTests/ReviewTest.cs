using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Context;
using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using Business_logic_Layer.Container;
using System.Linq;
using Data_Access_Layer.DTOs;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ReviewTest
    {

        public IReview_Context review_Context;
        public Review_Container container;


        [TestInitialize]
        public void Setup()
        {

            review_Context = new Review_Context_Stub();
            container = new Review_Container(review_Context);
        }

        [TestMethod]
        public void AddReviewTrue()
        {
            //Arrange
            Review_Model model = new Review_Model(1, "mooi", 5,1);
            //Act
            Review_Model TestResult = container.AddReview(model);
            //Assert
            Assert.AreEqual(TestResult.Review, "mooi");
            Assert.AreEqual(TestResult.ItemID, 1);
            Assert.AreEqual(TestResult.Score, 5);
            Assert.AreEqual(TestResult.ReviewID, 1);

        }

        [TestMethod]
        public void GetallReviewsTrue()
        {
            //Arrange

            //Act
            List<Review_Model> TestResult = container.GetAllReviews(1);
            //Assert
            Assert.AreEqual(2, TestResult.Count());
        }

        [TestMethod]
        public void AddReviewLike()
        {
            //Arrange
            Review_Model review = new Review_Model(1);
            User_Model user = new User_Model(1);
            //Act
            bool TestResult = container.AddLike(review.ReviewID, user.User_ID);
            //Assert
            Assert.IsTrue(TestResult);
        }

        [TestMethod]
        public void GetallLikesTrue()
        {
            //Arrange
            Review_Model review = new Review_Model(1);
            //Act
            List<Review_Model> TestResult = container.GetAllLikes(review.ReviewID);
            //Assert
            Assert.AreEqual(3, TestResult.Count());
        }

        [TestMethod]
        public void GetallLikes()
        {
            //Arrange
            Review_Model review = new Review_Model(1);
            User_Model user = new User_Model(1);
            //Act
            container.AddLike(review.ReviewID, user.User_ID);
            List<Review_Model> TestResult = container.GetAllLikes(review.ReviewID);
            //Assert
            Assert.AreEqual(4, TestResult.Count());
        }
    }
}
