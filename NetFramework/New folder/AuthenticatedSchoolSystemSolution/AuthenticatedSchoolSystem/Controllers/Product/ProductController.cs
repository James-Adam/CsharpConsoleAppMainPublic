using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Controllers.Product
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //apply route contraint

        public ActionResult Details(int ProductId)
        {
            ViewBag.ProductId = ProductId;

            return View();
        }
    }
}