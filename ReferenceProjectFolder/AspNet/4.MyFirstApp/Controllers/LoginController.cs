using _4.MyFirstApp.Models;
using _4.MyFirstApp.Services.Business;
using System.Web.Mvc;

namespace _4.MyFirstApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }

        public string Login(UserModel userModel)
        {
            //return "Results: username = " + userModel.Username + " password = " + userModel.Password;
            SecurityService securityService = new SecurityService();
            bool success = securityService.Authenticate(userModel);
            return success ? "Success login" : "Failure.";
        }
    }
}