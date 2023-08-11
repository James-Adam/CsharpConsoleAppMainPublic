using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AuthenticatedSchoolSystem
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //Trouble shooting application security !! Required
        //void Application_Error(object sender, EventArgs e)
        //{
        //    Exception ex = Server.GetLastError();
        //    if (ex.GetType() == typeof(HttpException))
        //    {
        //        Server.Transfer("MyCustomErrorPage.aspx");

        //    }
        //    else
        //    {
        //        Response.Write("<h3>My Custom Error Page</h3>\n");
        //        Response.Write("<p>" + ex.Message + "</p>\n");
        //        Response.Write("<p>" + ex.StackTrace + "</p>\n");
        //    }
        //    Server.ClearError();
        //}

        //Configure custom error settings
        protected void Application_Error(object sender, EventArgs e)
        {
            _ = Server.GetLastError();

            //log error
            //LogException(exception);

            ////process 404 http errors
            //var httpException = exception as HttpException;
            //if(httpException != null && httpException.GetHttpCode()== 404)
            //{
            //    Response.Clear();
            //    Server.ClearError();
            //    Response.TrySkipIisCustomErrors = true;

            //    //Call target controller and pass the routeData
            //    IController errorController = EngineContext.Current.Resolve<CommonController>();
            //}
        }
    }
}