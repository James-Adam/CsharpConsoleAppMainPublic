using System.Web;
using System.Web.Mvc;

namespace _4.MyFirstApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public string Welcome(string Name, int numTimes = 1)
        {
            return HttpUtility.HtmlEncode("Hello, " + Name + " Number of Times is " + numTimes);
        }

        public string Welcome2(string Name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello, " + Name + " ID is " + ID);
        }

        public ActionResult TestView()
        {
            //return testview.cshtml - view maps to the action method name

            return View();
        }

        public ActionResult ErrorMessage()
        {
            //return testview.cshtml - view maps to the action method name

            return View();
        }

        public string PrintMessage()
        {
            return "<h1>Welcome</h1><P>This is the first custom page of your application</p>";
        }
    }
}