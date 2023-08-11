using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Controllers;
using System.Web.Mvc;

namespace SchoolSystem.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public async void DTC()
        {
            // Arrange
            DecisionTreeController dt = new DecisionTreeController();



            // Assert
            Assert.AreEqual(await dt.Sample(new byte[] { }, "test", 1, @"c:\test"), 1);
        }
    }
}



