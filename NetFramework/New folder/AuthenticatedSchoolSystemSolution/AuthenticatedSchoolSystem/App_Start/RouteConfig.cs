using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthenticatedSchoolSystem
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //user friendly routes
            routes.Add("MYSEORoute", new SEORoute("home/about/{id}",
                new RouteValueDictionary(new { controller = "Home", action = "About" }), new MvcRouteHandler()));
            //configuring controller route parameter
            _ = routes.MapRoute(
                "Contact",
                "Contact",
                new { controller = "Home", action = "Contact" }
            );
            //   routes.MapRoute(
            //    name: "ContactUs",
            //    url: "ContactUs",
            //    defaults: new { controller = "Home", action = "Contact" }
            //);

            //Defining a route to handle a url pattern
            _ = routes.MapPageRoute("ProductsByNameRoute", "Product/{productName}", "~/ProductDetails.aspx");

            //apply route contraint - not working properly
            _ = routes.MapRoute("Product", "Product/{productId}", new { controller = "Product", action = "Details" },
                new { ProductId = @"\d+" });
            _ = routes.MapRoute("Product2", "Product/{productId}", new { controller = "Product", action = "Index" });

            //defining Routes that ignore a URL Pattern
            routes.IgnoreRoute("Person/");
            _ = routes.MapRoute("Student", "Student/{action}/{id}",
                new { controller = "Person", action = "Index", id = UrlParameter.Optional });

            _ = routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }

    public class SEORoute : Route
    {
        public SEORoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler) : base(url, defaults,
            routeHandler)
        {
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData rd = base.GetRouteData(httpContext);

            if (rd != null && rd.Values.ContainsKey("id"))
            {
                try
                {
                    switch (rd.Values["id"].ToString())
                    {
                        case "positive":
                            rd.Values["id"] = 1;
                            break;

                        case "negative":
                            rd.Values["id"] = -1;
                            break;

                        case "zero":
                            rd.Values["id"] = 0;
                            break;

                        default:
                            _ = rd.Values.Remove("id");
                            break;
                    }
                }
                catch
                {
                    _ = rd.Values.Remove("id");
                }
            }

            return rd;
        }
    }
}