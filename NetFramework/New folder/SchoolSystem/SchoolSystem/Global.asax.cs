using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SchoolSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Register custom routes
            //var routePublisher = EngineContext.Current.Resolve<IRoutePublisher>();
            //routePublisher.RegisterRoutes(routes);

            routes.MapRoute(
               "Blog",                                           // Route name
               "Archive/{entryDate}",                            // URL with parameters
               new { controller = "Archive", action = "Entry" },  // Parameter defaults

                routes.MapRoute(
                "Default", //route name
                "{controller}/{action}/{id}", // url with perameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "SchoolSystem.Controllers" }

                           )
           );



        }
    }
}
