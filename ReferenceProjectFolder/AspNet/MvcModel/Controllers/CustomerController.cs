using MvcModel.Models;
using System.Web.Mvc;

namespace MvcModel.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            Customer customer = new Customer
            {
                Id = 1,
                Name = "Bob Adam",
                Email = "bobadam.info@gmail.com"
            };

            return View("Index", customer);
        }
    }
}