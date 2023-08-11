using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StateConfiguration.Models;
using StateConfiguration.Models.Configurations;
using System.Collections;
using System.Diagnostics;

namespace StateConfiguration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index([FromServices]IConfiguration cnfg, Services.HelloService svc)
        {
            var Evs = Environment.GetEnvironmentVariables();
            ViewBag.Env = Evs as Hashtable;

            var cnstr = cnfg["SkillKeys:ConString"];


            //services
            ViewBag.Message = svc.Message;

            //var rst = StateConfiguration.Properties.Settings.Default.key1;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       //custom settings
        public IActionResult DoOptionsPatterns([FromServices] IOptions<CustomSettings> settings)
        {
            return View();
        }

        //file configuration provider
        public IActionResult IniFileSettings([FromServices]IConfiguration conf)
        {
            var data = conf.GetSection("section0:key1");
            ViewBag.Value = data;




            return View();
        }
    }
}