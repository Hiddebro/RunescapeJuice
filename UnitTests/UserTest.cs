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
            User_Model TestResult = container.AddUser(user);
            //Assert
            Assert.AreEqual(TestResult.User_ID, 1);
            Assert.AreEqual(TestResult.IsAdmin, 1);
            Assert.AreEqual(TestResult.Username, "Henkaa");
            Assert.AreEqual(TestResult.Password, "Boos");

        }

        [TestMethod]
        public void AddUserFalse()
        {
            //Arrange
            User_Model user = new User_Model(0,4,"Henk", "Boos");
            //Act
            User_Model TestResult = container.AddUser(user);
            //Assert
            Assert.AreNotEqual(TestResult.IsAdmin, 1);
            Assert.AreNotEqual(TestResult.User_ID, 1);

        }


        [TestMethod]
        public void GetByNameTrue()
        {
            //Arrange
            User_Model user = new User_Model("Henk", "Boos");
            //Act
            User_Model TestResult = container.GetByName(user);
            //Assert
            Assert.AreEqual(TestResult.User_ID, 1);
            Assert.AreEqual(TestResult.IsAdmin, 1);
        }

        [TestMethod]
        public void GetByNameFalse()
        {
            //Arrange
            User_Model user = new User_Model("Henk", "Boos");
            //Act
            User_Model TestResult = container.GetByName(user);
            //Assert
            Assert.AreNotEqual(TestResult.User_ID, 0);
            Assert.AreNotEqual(TestResult.IsAdmin, 0);
        }
    }
}