using _3.MvcWebApplication.Models.cf;
using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace _3.MvcWebApplication.Controllers
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
            Database.SetInitializer(new DropCreateDatabaseAlways<EntityContext>());

            Student student = new Student
            {
                StudentID = "123456",
                FirstName = "Niel",
                LastName = "Parks",
                DOB = new DateTime(1968, 4, 12),
                Grade = "12"
            };

            Staff staff = new Staff
            {
                StaffID = "123456",
                FirstName = "John",
                LastName = "Snow",
                AnnualSalary = "$12000"
            };

            using (EntityContext context = new EntityContext())
            {
                _ = context.Students.Add(student);
                _ = context.Staffs.Add(staff);
                _ = context.SaveChanges();
            }

            return View();
        }
    }
}