using Microsoft.AspNet.SignalR;

namespace AuthenticatedSchoolSystem.Back_End.Filters
{
    public class PipeLineFilter : AuthorizeAttribute
    {
        //public override void OnAuthorization(HttpActionContext actionContext)
        //{
        //    base.OnAuthorization(actionContext);
        //    if(actionContext.Request.Headers.GetValues("mySecurityToken") != null)
        //    {
        //        string mySecurityToken = Convert.ToString(actionContext.Request.Headers.GetValues("mySecurityToken").FirstOrDefault());
        //        if (mySecurityToken == "badToken")
        //        {
        //            HttpContext.Current.Response.AddHeader("mySecurityToken", mySecurityToken);
        //            HttpContext.Current.Response.AddHeader("mySecurityStatus", "NeedAuthorization");
        //        }
        //        else
        //        {
        //            HttpContext.Current.Response.AddHeader("mySecurityToken", mySecurityToken);
        //            HttpContext.Current.Response.AddHeader("mySecurityStatus", "FullyAuthorized");
        //        }
        //    }
        //    else
        //    {
        //        HttpContext.Current.Response.AddHeader("mySecurityToken", String.Empty);
        //        HttpContext.Current.Response.AddHeader("mySecurityStatus", "NoAuthorization");
        //    }
        //}
    }
}