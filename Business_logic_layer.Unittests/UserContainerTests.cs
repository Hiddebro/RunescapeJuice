using Business_logic_Layer.Container;
using Data_Access_Layer.Context;
using Data_Access_Layer.Interfaces;
using NUnit.Framework;

namespace Business_logic_layer.Unittests
{
    public class Tests
    { 

     //   private I_User_Context user_Context;
    //    private User_Container container;
 
        [SetUp]
        public void Setup()
        {
         //   user_Context = new User_Context();
        //    container = new User_Container(user_Context);
        }

        [Test]
        [TestCase(12, 3)]
        [TestCase(12, 3)]
        [TestCase(12, 3)]
        [TestCase(12, 3)]

        [TestCase(12, 3)]
        [TestCase(12, 3)]
        [TestCase(12, 3)]
        public void Insert_NewUser_Return2(int test, int uitkomst)
        {


           // Assert.
        }
    }
}