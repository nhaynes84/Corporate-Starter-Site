using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using XYZCorpTempSite;
using XYZCorpTempSite.Controllers;
using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();
            
            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Edit()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();

            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Edit() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            var mockRepo = new Mock<IRepository>();

            HomeController controller = new HomeController(mockRepo.Object);

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
