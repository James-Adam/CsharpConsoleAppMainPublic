using MvcModel.Models;
using System;
using System.Web.Mvc;

namespace MvcModel.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            Employee employee = new Employee
            {
                Id = 1111,
                Name = "James Adam",
                Email = "jamesadam.info@gmail.com",
                BirthdDate = DateTime.Now.ToString()
            };
            return View("Index", employee);
        }
    }
}