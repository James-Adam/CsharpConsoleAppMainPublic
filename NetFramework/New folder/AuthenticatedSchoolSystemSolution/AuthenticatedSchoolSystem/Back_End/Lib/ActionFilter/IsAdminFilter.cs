using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace AuthenticatedSchoolSystem.Back_End.Lib.ActionFilter
{
    public class IsAdminFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            System.Security.Principal.IPrincipal user = filterContext.HttpContext.User;
            bool isAdmin = user.IsInRole("Admin");
            if (user.Identity.IsAuthenticated && !isAdmin)
            {
                UrlHelper helper = new UrlHelper(filterContext.RequestContext);
                string url = helper.Action("AdminError", "Account");
                filterContext.Result = new RedirectResult(url);
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            System.Security.Principal.IPrincipal user = filterContext.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }
    }
}