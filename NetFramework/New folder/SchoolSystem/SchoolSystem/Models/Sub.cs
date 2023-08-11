using System;
using System.Web;

namespace SchoolSystem.Models
{
    public class Sub
    {
        public static string sub(HttpContext context)
        {
            return DateTime.Now.ToString();
        }
    }
}