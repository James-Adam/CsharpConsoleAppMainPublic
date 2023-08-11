using System;
using System.Web;

namespace AuthenticatedSchoolSystem.Back_End.CustomModule
{
    public class SayHelloModule : IHttpModule
    {
        public string ModuleName => "SayHelloModule";

        public void Init(HttpApplication application)
        {
            application.BeginRequest += Application_BeginRequest;
            application.EndRequest += Application_EndRequest;
        }

        public void Dispose()
        {
            // Method intentionally left empty.
        }

        private void Application_EndRequest(object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            context.Response.Write("<h1><font color=cornflowerblue>" + "Hello, Greeting!!!" + "</font></h1>");
        }

        private void Application_BeginRequest(object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            context.Response.Write("<h1><font color=cornflowerblue>" + "Bye </font></h1>");
        }
    }
}