using System;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    //Using authentication to secure a web service
    public class WebServiceAuthentication : IHttpModule, IDisposable
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += AuthenticateRequests;
            context.EndRequest += EndRequests;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private void EndRequests(object sender, EventArgs e)
        {
            if (HttpContext.Current.Response.StatusCode == 401)
            {
                HttpContext.Current.Response.Headers.Add("WWW-Authenticate", @"Basic realm='myRealym'");
            }
        }

        private void AuthenticateRequests(object sender, EventArgs e)
        {
            string ah = HttpContext.Current.Request.Headers["Authorization"];
            if (ah != null)
            {
                AuthenticationHeaderValue ahv = AuthenticationHeaderValue.Parse(ah);
                if (ahv.Parameter != null)
                {
                    _ = Encoding.GetEncoding("iso-8859-1").GetString(Convert.FromBase64String(ahv.Parameter))
                        .Split(':');
                }
            }
        }
    }
}