using Microsoft.AspNetCore.Mvc;

namespace StateConfiguration.Controllers
{
    public class EnvController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
