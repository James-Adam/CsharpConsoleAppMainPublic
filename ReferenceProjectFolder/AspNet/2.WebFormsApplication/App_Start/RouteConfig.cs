using Microsoft.AspNet.FriendlyUrls;
using System.Web.Routing;

namespace _2.WebFormsApplication
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            FriendlyUrlSettings settings = new FriendlyUrlSettings
            {
                AutoRedirectMode = RedirectMode.Permanent
            };
            routes.EnableFriendlyUrls(settings);
        }
    }
}