using System;
using System.Web;

namespace AuthenticatedSchoolSystem.Back_End.Cookies
{
    public static class Sub
    {
        public static string sub(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}