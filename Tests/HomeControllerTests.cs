using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using SISTEM2021HelloWorld.Controllers;
using SISTEM2021HelloWorld.Models;
using System;

namespace Tests
{
    public class HomeControllerTests
    {
        #region Fields

        public HomeController controller;

        #endregion

        #region Test Setup

        [SetUp]
        public void Setup()
        {
            var logger = Substitute.For<ILogger<HomeController>>();
            controller = new HomeController(logger);
        }

        #endregion

        #region .Index() Tests

        [Test]
        public void TestIndexAction()
        {
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);

            var model = result.Model as HomePageViewModel;

            Assert.IsNotNull(model);
            Assert.AreEqual(model.Message, "My very important message!");
            Assert.GreaterOrEqual(DateTime.Now, model.Date);
        }

        #endregion
    }
}