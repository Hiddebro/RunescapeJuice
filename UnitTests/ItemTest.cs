using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Context;
using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using Business_logic_Layer.Container;
using System.Linq;

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
            Item_Model item = new Item_Model(5 , "SGS" , 100000, 50);
            //Act
            Item_Model itema = container.AddItem(item);
            //Assert
            Assert.AreEqual(itema.ItemID, 5);
            Assert.AreEqual(itema.ItemName, "SGS");
            Assert.AreEqual(itema.Price, 100000);
            Assert.AreEqual(itema.Amount, 50);
        }
      
       

        [TestMethod]
        public void DeleteItemTrue()
        {
            //Arrange
            
            //Act  
            container.DeleteItem(1);
            container.GetAllItems();
            //Assert
            Assert.AreEqual(3 , container.GetAllItems().Count());
        }
         [TestMethod]
        public void GetAllItemsTrue()
        {
            //Arrange

            //Act
            container.GetAllItems();
            //Assert
            Assert.AreEqual(4, container.GetAllItems().Count());
        }

        [TestMethod]

        public void AddItemToUserTrue()
        {
            //Arrange
            
            User_Model user = new User_Model(1,0);
            Item_Model item5 = new Item_Model(2, "SGS", 100, 10, 100);

            //Act
            container.AddItemToUser(item5, user);
            //Assert
            Assert.AreEqual(2,container.AddItemToUser(item5,user).ItemID);
        }
    }
}
