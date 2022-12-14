using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data_Access_Layer.Context;
using Business_logic_Layer.Models;
using Data_Access_Layer.Interfaces;
using Business_logic_Layer.Container;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        static I_User_Context user_Context = new User_Context();
        User_Container container = new User_Container(user_Context);
       

        [TestMethod]
        public void LoginTrue()
        {
            //Arrange
            User_Model user = new User_Model("Henk","Boos","HenkBoos@gmail.com");
            //Act
            container.Equals(user);
            //Assert
            Assert.IsTrue(container.Equals(user));   
        }
    }
}