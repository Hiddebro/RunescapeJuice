using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Context;
using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using Business_logic_Layer.Container;
using System.Linq;


namespace UnitTests
{
    [TestClass]
    public class UserTest
    {
        static IUser_Context user_Context = new User_Context_Stub();
        User_Container container = new User_Container(user_Context);
       

        [TestMethod]
        public void AddUserTrue()
        {
            //Arrange
            User_Model user = new User_Model(1, 1, "Henkaa", "Boos");
            //Act
            User_Model usera = container.AddUser(user);
            //Assert
            Assert.AreEqual(usera.User_ID, 1);
            Assert.AreEqual(usera.IsAdmin, 1);
            Assert.AreEqual(usera.Username, "Henkaa");
            Assert.AreEqual(usera.Password, "Boos");
        }

        [TestMethod]
        public void AddUserFalse()
        {
            //Arrange
            User_Model user = new User_Model(1, null, "Henk", "Boos");
            //Act
            container.AddUser(user);
            //Assert
            Assert.IsFalse(User_Context_Stub.tryaddperson);

        }

        [TestMethod]
        public void GetByIsAdminTrue()
        {
            //Arrange
            User_Model a = new User_Model(1, 1, "Henk", "Boos");
            //Act
            User_Model ax = container.GetByIsAdmin(a);
            //Assert
            Assert.AreEqual(ax.IsAdmin, 1);
        }

        [TestMethod]
        public void GetByIsAdminFalse()
        {
            //Arrange
            User_Model b = new User_Model(1, 0, "Henk", "Boos");
            //Act
            User_Model bx = container.GetByIsAdmin(b);
            //Assert
            Assert.AreNotEqual(bx.IsAdmin, 1);
        }

        [TestMethod]
        public void GetByNameTrue()
        {
            //Arrange
            User_Model c = new User_Model(1, 1, "Henk", "Boos");
            //Act
            User_Model cx = container.GetByName(c);
            //Assert
            Assert.AreEqual(cx.Username, "Henk");
        }

        [TestMethod]
        public void GetByNameFalse()
        {
            //Arrange
            User_Model d = new User_Model(1, 1, "Henk", "Boos");
            //Act
            User_Model dx = container.GetByName(d);
            //Assert
            Assert.AreNotEqual(dx.Username, "Test");
        }
    }
}