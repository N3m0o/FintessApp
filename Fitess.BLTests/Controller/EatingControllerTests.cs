﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitess.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitess.BL.Model;

namespace Fitess.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50,500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            eatingController.Add(food,100);

            Assert.AreEqual(food.Name,eatingController.Eating.Food.First().Key.Name);
        }
    }
}