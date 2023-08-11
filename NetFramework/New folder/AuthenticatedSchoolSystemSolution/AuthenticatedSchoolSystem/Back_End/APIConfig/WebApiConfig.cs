using System.Web.Http;
using System.Web.Http.Batch;

namespace AuthenticatedSchoolSystem.Back_End.APIConfig
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // web api configuration and services

            //web API routes
            config.MapHttpAttributeRoutes();

            _ = config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new { id = RouteParameter.Optional }
            );

            _ = config.Routes.MapHttpRoute(
                "CustomApi",
                "api/{controller}/{ida}/{idb}",
                new { ida = RouteParameter.Optional, idb = RouteParameter.Optional }
            );

            //using a request batch to reduce requests
            _ = config.Routes.MapHttpBatchRoute(
                "myBatch",
                "api/mybatch",
                new DefaultHttpBatchHandler(GlobalConfiguration.DefaultServer)
            );

            //using filters to extend authentication
            //need to link filter page
            //config.Filters.Add(new Back_End.Filters.PipeLineFilter());
        }
    }
}