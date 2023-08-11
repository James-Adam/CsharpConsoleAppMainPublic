using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolSystem.Routes
{
    public class RouteProvider : IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            //Default
            routes.MapRoute("Default", //route name
                "{controller}/{action}/{id}", // url with perameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "SchoolSystem.Controllers" });
        }
    }
}