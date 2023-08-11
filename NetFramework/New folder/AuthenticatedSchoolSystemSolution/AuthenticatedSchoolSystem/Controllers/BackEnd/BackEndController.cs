using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.BackEnd
{
    public class BackEndController : Controller
    {
        // GET: BackEnd
        public ActionResult Index()
        {
            return View();
        }

        //	<!--storing custom settings in a configuration file-->
        //public ActionResult CheckLoginRule()
        //{
        //    var appSettings = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
        //    if (Convert.ToBoolean(appSettings.AppSettings.Settings["RequireReAuthOnAllLogins"].Value))
        //    {
        //        return RedirectToAction("Login");
        //    }

        // return Content("");

        //}
    }
}