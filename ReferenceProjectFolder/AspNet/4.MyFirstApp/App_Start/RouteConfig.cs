using System.Web.Mvc;
using System.Web.Routing;

namespace _4.MyFirstApp
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            _ = routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            _ = routes.MapRoute(
                "Login",
                "{Login}",
                new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
            _ = routes.MapRoute(
                "Test",
                "test/{action}",
                new { controller = "Test", action = "PrintMessage" }
            );
        }
    }
}