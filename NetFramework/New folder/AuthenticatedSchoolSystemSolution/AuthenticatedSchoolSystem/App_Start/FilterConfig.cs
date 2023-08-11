using AuthenticatedSchoolSystem.Back_End.Lib.ActionFilter;
using System.Web.Mvc;

namespace AuthenticatedSchoolSystem
{
    public static class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ActionLogFilter());
        }
    }
}