using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using _3.MvcWebApplication.Controllers;
using _3.MvcWebApplication;

namespace MVC_UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            //arrange
            HomeController controller = new HomeController();

            //act
            ViewResult result = controller.Index() as ViewResult;

            //assert
            Assert.IsNotNull(result);
        }
    }
}
