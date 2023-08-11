using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Controller c = new AuthenticatedSchoolSystem.Controllers.HomeController();
            AuthenticatedSchoolSystem.Back_End.HTTP.MyHttpContext.SetMyContext(c);


            string user = c.HttpContext.User.Identity.Name;
            Assert.AreEqual(user, "myUserName");
        }
    }
}
