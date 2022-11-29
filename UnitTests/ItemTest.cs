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
        static IItem_Context item_Context = new Item_Context_Stub();
        Item_Container container = new Item_Container(item_Context);

        [TestMethod]
        public void AddItemTrue()
        {
            //Arrange
            Item_Model item = new Item_Model(4 , "SGS" , 100000, 50);
            //Act
            Item_Model itema = container.AddItem(item);
            //Assert
            Assert.AreEqual(itema.ItemID, 4);
            Assert.AreEqual(itema.ItemName, "SGS");
            Assert.AreEqual(itema.Price, 100000);
            Assert.AreEqual(itema.Amount, 50);
        }
      
        [TestMethod]
        public void GetAllItemsTrue()
        {
            //Arrange
             
            //Act
            container.GetAllItems();
            //Assert
            Assert.AreEqual(4, Item_Context_Stub.items.Count);
        }


    }
}
