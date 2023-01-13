using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Context;
using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using Business_logic_Layer.Container;
using System.Linq;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ItemTest
    {
        public IItem_Context item_Context;
        public Item_Container container;



        [TestInitialize]
        public void Setup()
        {
            item_Context = new Item_Context_Stub();
            container = new Item_Container(item_Context);
        }


        [TestMethod]
        public void AddItemTrue()
        {
            //Arrange
            Item_Model item = new Item_Model(5, "SGS", 100000, 50);
            //Act
            Item_Model TestResult = container.AddItem(item);
            //Assert
            Assert.AreEqual(TestResult.ItemID, 5);
            Assert.AreEqual(TestResult.ItemName, "SGS");
            Assert.AreEqual(TestResult.Price, 100000);
            Assert.AreEqual(TestResult.Amount, 50);
        }



        [TestMethod]
        public void DeleteItemTrue()
        {
            //Arrange

            //Act  
            container.DeleteItem(1);
            List<Item_Model> TestResultList = container.GetAllItems();
            //Assert
            Assert.AreEqual(3, TestResultList.Count);
        }

        [TestMethod]
        public void DeleteItemFalse()
        {
            //Arrange

            //Act  
            container.DeleteItem(1);
            List<Item_Model> TestResultList = container.GetAllItems();
            //Assert
            Assert.AreEqual(3, TestResultList.Count);
        }


        [TestMethod]
        public void GetAllItemsTrue()
        {
            //Arrange

            //Act
            List<Item_Model> TestResultList = container.GetAllItems();
            //Assert
            Assert.AreEqual(4, TestResultList.Count());
        }

        [TestMethod]

        public void GetUserItems()
        {
            //Arrange
            User_Model user = new User_Model(1, 0);
            //Act
            List<Item_Model> TestResultList = container.GetAllUserItems(user);
            //Assert
            Assert.AreEqual(4, TestResultList.Count());
        }

        [TestMethod]

        public void AddItemToUserAndGetList()
        {
            //Arrange
            User_Model user = new User_Model(1, 0);
            Item_Model item = new Item_Model(7, "SGS", 100000, 50, 100);
            Item_Model item2 = new Item_Model(8, "BGS", 1000, 20, 100);
            //Act
            container.AddItemToUser(item, user, item.Amount);
            container.AddItemToUser(item2, user, item2.Amount);
            List<Item_Model> TestResultList = container.GetAllUserItems(user);
            //Assert
            Assert.AreEqual(6, TestResultList.Count());
        }

        [TestMethod]
        public void ItemIsNotDouble()
        {
            //Arrange
            User_Model user = new User_Model(1, 0);
            Item_Model item = new Item_Model(7, "BGS", 100000, 50);
            int amount = 7;
            //Act
            Item_Model TestResult = container.DoubleItems(item, user, amount);
            //Assert
            Assert.AreEqual("BGS", TestResult.ItemName);
        }

        [TestMethod]
        public void ItemIsDouble()
        {
            //Arrange
            User_Model user = new User_Model(1, 0);
            Item_Model item = new Item_Model(7, "SGS", 100000, 50);
            int amount = 7;
            //Act
            Item_Model TestResult = container.DoubleItems(item, user, amount);
            //Assert
            Assert.AreEqual("SGS", TestResult.ItemName);
        }

        [TestMethod]
        public void SellItemTrue()
        {
            //Arrange
            User_Model user = new User_Model(1, 0);
            //Act
            container.SellItem(1, 1, 50);
            List<Item_Model> TestResultList = container.GetAllUserItems(user);
            //Assert
            Assert.AreEqual(3, TestResultList.Count);
        }

        [TestMethod]
        public void SellItemFalse()
        {
            //Arrange
            User_Model user = new User_Model(1, 0);
            //Act
            container.SellItem(0, 1, 50);
            List<Item_Model> TestResultList = container.GetAllUserItems(user);
            //Assert
            Assert.AreEqual(4, TestResultList.Count);
        }

        [TestMethod]
        public void CheckIfOwnedTrue()
        {
            //Arrange
            User_Model user = new User_Model(1);
            Item_Model item = new Item_Model(5, "SGS", 100000, 50);
            //Act
            bool TestResultBool = container.CheckIfOwned(item.ItemID, user.User_ID);
            //Assert
            Assert.IsTrue(TestResultBool);
        }

        [TestMethod]
        public void CheckIfOwnedFalse()
        {
            //Arrange
            User_Model user = new User_Model(1);
            Item_Model item = new Item_Model(7, "BGS", 100000, 50);
            //Act
            bool TestResultBool = container.CheckIfOwned(item.ItemID, user.User_ID);
            //Assert
            Assert.IsFalse(TestResultBool);
        }


        [TestMethod]
        public void GetItemData_True()
        {
            //Arrange
            Item_Model item = new Item_Model(6);
            //Act
            Item_Model TestResult = container.GetItemData(item.ItemID);
            //Assert
            Assert.AreEqual(6, TestResult.ItemID);
            Assert.AreEqual("ZGS", TestResult.ItemName);
            Assert.AreEqual(50, TestResult.TotalItems);
            Assert.AreEqual(10, TestResult.Price);
        }

        [TestMethod]
        public void GetItemData_NoItem()
        {
            //Arrange
            Item_Model item = new Item_Model(9);
            //Act
            Item_Model TestResult = container.GetItemData(item.ItemID);
            //Assert
            Assert.AreEqual(9, TestResult.ItemID);
            Assert.AreEqual(null, TestResult.ItemName);
        }




    }
}

