using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Back_End.Filters
{
    public class MyExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            filterContext.Controller.ViewBag.MyExceptionMessage1 = "OnException  method called";
        }
    }
}