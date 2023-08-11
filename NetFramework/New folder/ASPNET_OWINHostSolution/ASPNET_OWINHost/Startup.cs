using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using System.Web.Http;

[assembly: OwinStartup(typeof(ASPNET_OWINHost.Startup))]

namespace ASPNET_OWINHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            appBuilder.UseWebApi(config);
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
