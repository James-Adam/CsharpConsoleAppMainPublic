using AuthenticatedSchoolSystem.Models.HR;
using System;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem.Back_End.Lib.ActionFilter
{
    public class ActionLogFilter : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            using (MyHREntities myDB = new MyHREntities())
            {
                ActionLog log = new ActionLog
                {
                    //ID = filterContext,
                    Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    Action = filterContext.ActionDescriptor.ActionName,
                    HttpMethod = filterContext.RequestContext.HttpContext.Request.HttpMethod,
                    ActionDate = DateTime.Now,
                    UrlHelper = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri
                };
                //_ = myDB.ActionLog.Add(log);
                //myDB.SaveChanges();
                OnActionExecuted(filterContext);
            }
        }
    }
}