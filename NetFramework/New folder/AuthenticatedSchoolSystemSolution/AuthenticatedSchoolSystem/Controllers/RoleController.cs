using AuthenticatedSchoolSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext ApplicationDbContextcontext;

        public RoleController()
        {
            ApplicationDbContextcontext = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            System.Collections.Generic.List<IdentityRole> Roles = ApplicationDbContextcontext.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            IdentityRole Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            _ = ApplicationDbContextcontext.Roles.Add(Role);
            _ = ApplicationDbContextcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}