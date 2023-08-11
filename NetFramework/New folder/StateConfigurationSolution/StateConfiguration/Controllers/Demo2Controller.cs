using Microsoft.AspNetCore.Mvc;

namespace StateConfiguration.Controllers
{
    public class Demo2Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
