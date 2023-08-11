using AuthenticatedSchoolSystem.Back_End.Lib.ActionFilter;
using AuthenticatedSchoolSystem.Models.HR;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.HR
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [ActionName("Main")]
        public ActionResult Index()
        {
            using (MyHREntities myDB = new MyHREntities())
            {
                System.Collections.Generic.List<Employee> employee = (from a in myDB.Employees select a).ToList();
                return View(employee);
            }
        }

        [HttpGet] // only response to get
        [ActionLogFilter]
        public ActionResult Edit()
        {
            Employee employee = new Employee
            {
                firstName = "Kathy",
                lastName = "Cruz",
                Title = "CEO",
                DOB = new DateTime(1997, 04, 10),
                Salary = "$120,000"
            };

            return View(employee);
        }

        [HttpPost] // only response to get
        [ActionLogFilter]
        public ActionResult Edit(Employee model)
        {
            using (MyHREntities myDB = new MyHREntities())
            {
                // edit employee record in database
            }

            return View(model);
        }
    }
}