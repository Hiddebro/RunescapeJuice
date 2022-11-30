using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Context;
using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using Business_logic_Layer.Container;
using Business_logic_Layer.Converters;
using System.Linq;
using System;

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


            //user get
        }

        [TestMethod]
        public void AddUserFalse()
        {
            //Arrange
            User_Model user = new User_Model(1,"Henk", "Boos");
            //Act
            container.AddUser(user);
            //Assert
            Assert.IsFalse(User_Context_Stub.tryaddperson);

        }


        [TestMethod]
        public void GetByNameTrue()
        {
            //Arrange
            User_Model c = new User_Model("Henk", "Boos");
            //Act
            User_Model user = container.GetByName(c);
            //Assert
            Assert.AreEqual(user.User_ID, 1);
            Assert.AreEqual(user.IsAdmin, 1);
        }

        [TestMethod]
        public void GetByNameFalse()
        {
            //Arrange
            User_Model d = new User_Model("Henk", "Boos");
            //Act
            User_Model user = container.GetByName(d);
            //Assert
            Assert.AreNotEqual(user.User_ID, 0);
            Assert.AreNotEqual(user.IsAdmin, 0);
        }
    }
}