using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace iSchool.Controllers
{
    public class InitController : Controller
    {
        // GET: Init
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Init()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<Models.cf.EntityContext>());

            var student = new Models.cf.Student()
            {
                Id = "123456",
                FirstName = "James",
                LastName = "Adam",
                BirthDate = new DateTime(1997, 01, 22),
                Grade = "12",
            };
            using (var context = new Models.cf.EntityContext())
            {
                context.Students.Add(student);
                context.SaveChanges();

            };
            return View();
        }
    }
}