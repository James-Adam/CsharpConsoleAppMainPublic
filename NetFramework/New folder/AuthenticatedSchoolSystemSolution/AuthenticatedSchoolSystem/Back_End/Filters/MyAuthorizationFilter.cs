using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Back_End.Filters
{
    public class MyAuthorizationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.Controller.ViewBag.MyAuthorizationFilterMessage1 = "OnAuthorization method called";
        }
    }
}