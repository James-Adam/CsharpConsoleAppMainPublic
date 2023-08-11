using Microsoft.AspNetCore.Mvc;

namespace StateConfiguration.Controllers
{
    public class Demo1Controller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
