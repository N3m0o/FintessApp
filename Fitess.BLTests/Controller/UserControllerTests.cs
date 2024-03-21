using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitess.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitess.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SaveTest()
        {
           var userName = Guid.NewGuid().ToString();
           var userController = new UserController(userName);
            Assert.AreEqual(userName,userController.CurrentUser.Name);
            
            Assert.Fail();
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            var userName = Guid.NewGuid().ToString();
            var userController = new UserController(userName);
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 100;
            var height = 180;
            var gender = "man";
            userController.SetNewUserData(gender,birthDate,weight,height);
            var userController2 = new UserController(userName);
            Assert.AreEqual(userName,userController2.CurrentUser.Name);
        }
    }
}