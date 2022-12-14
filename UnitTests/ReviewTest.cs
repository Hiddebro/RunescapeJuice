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

        public List<Review_Model> TestResult { get; private set; }

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
            Review_Model model2 = container.AddReview(model);
            //Assert
            Assert.AreEqual(model2.Review, "mooi");
            Assert.AreEqual(model2.ItemID, 1);
            Assert.AreEqual(model2.Score, 5);

        }

        [TestMethod]
        public void GetallReviewsTrue()
        {
            //Arrange

            //Act
            TestResult = container.GetAllReviews(1);
            //Assert
            Assert.AreEqual(2, TestResult.Count());
        }
    }
}
