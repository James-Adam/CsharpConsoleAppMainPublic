using AuthenticatedSchoolSystem.Back_End.Filters;
using AuthenticatedSchoolSystem.Back_End.Lib.ActionFilter;
using AuthenticatedSchoolSystem.Back_End.Lib.ActionResults;
using AuthenticatedSchoolSystem.Back_End.myResource;
using AuthenticatedSchoolSystem.Back_End.OptimizationEncryption;
using AuthenticatedSchoolSystem.Models.Back_End;
using AuthenticatedSchoolSystem.Models.HR;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Web.Mvc;
using System.Web.Security.AntiXss;

namespace AuthenticatedSchoolSystem.Controllers
{
    [MyAuthorizationFilter]
    public class HomeController : Controller
    {
        [MyExceptionFilter]
        [Back_End.Filters.MyActionFilter]
        [ActionLogFilter]
        public ActionResult Index()
        {
            return View();
        }

        [ActionLogFilter]
        [MyHashActionFilter]
        [Authorize] //accessed by registered users
        [OutputCache(Duration = 10)]
        public ActionResult About(string q, string hash) //int? id = 123
        {
            if (hash.Length > 0)
            {
                ViewBag.Message =
                    string.Concat("Your application description page:", q, " *** ", hash); // id.ToString()
            }
            else
            {
                ViewBag.Message = "Your application description page";
            }

            return View();
        }

        //[MyActionFilter]
        [ActionLogFilter]
        [Authorize(Roles = "Admin")] // accessed by SuperUser
        public ActionResult Contact(string q)
        {
            //tracing
            Trace.WriteLine("My Trace Message");

            //Creating a Javascript Resource // globalization
            foreach (string c in new[] { "en", "es" })
            {
                CultureInfo ci = new CultureInfo(c);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;

                ResourceManager rm = new ResourceManager("AuthenticatedSchoolSystem.Back_End.myResource.Resource1",
                    typeof(Resource1).Assembly);
                ViewData["myOutput"] += string.Format("Culture: {0} -- {1}\n",
                    Thread.CurrentThread.CurrentUICulture.Name, rm.GetString("String1"));
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-ES");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("es-ES");

            ViewBag.Message = "Your contact page." + q;

            return View();
        }

        [HttpGet]
        [ValidateInput(false)]
        public ActionResult Blog()
        {
            BlogView blog = new BlogView();
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        [ActionLogFilter]
        public ActionResult Blog(BlogView blog)
        {
            blog.posts.Add(new Post { data = AntiXssEncoder.HtmlEncode(blog.MyPost.data, false) });
            return View(blog);
        }

        //Defining an mvc controller action reselt
        [ActionLogFilter]
        public FileActionResult UserGuideFile()
        {
            return new FileActionResult("UserGuide.pdf", "~/Back_End/Files/", "application/pdf");
        }

        [ActionLogFilter]
        public FileActionResult AboutFile()
        {
            return new FileActionResult("About.pdf", "~/Back_End/Files/", "application/pdf");
        }

        [IsAdminFilter]
        public ActionResult ActionLog()
        {
            using (MyHREntities myDB = new MyHREntities())
            {
                System.Collections.Generic.List<ActionLog> ActionLogs =
                    (from a in myDB.ActionLog select a).ToList();
                return View(ActionLogs);
            }
        }
    }
}