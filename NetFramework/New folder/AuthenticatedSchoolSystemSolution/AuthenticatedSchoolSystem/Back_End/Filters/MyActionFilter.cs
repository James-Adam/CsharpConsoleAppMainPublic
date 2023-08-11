using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Back_End.Filters
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.MyActionFilterMessage1 = "OnActionExecuted method called";
            base.OnActionExecuted(filterContext);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.MyActionFilterMessage2 = "OnActionExecuting method called";
            base.OnActionExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.MyActionFilterMessage3 = "OnResultExecuted method called";
            base.OnResultExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.MyActionFilterMessage4 = "OnResultExecuting method called";
            base.OnResultExecuting(filterContext);
        }
    }
}