using Microsoft.AspNetCore.Mvc;

namespace StateConfiguration.Controllers
{
    public class AppStateController : Controller
    {
        public IActionResult Index()
        {

            string Val = "";

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("SampleKey")))            
            {
                Val = HttpContext.Session.GetString("SampleKey");
            }
            else
            {
                HttpContext.Session.SetString("SampleKey", "Test Data !!");
            }
            ViewBag.SessionData = Val;

            return View();
        }
    }
}
