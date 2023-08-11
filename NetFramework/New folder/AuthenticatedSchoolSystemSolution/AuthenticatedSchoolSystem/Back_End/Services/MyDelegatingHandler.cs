using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AuthenticatedSchoolSystem.Back_End.Services
{
    //Creating a Pipeline Process
    public class MyDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string mydata = HttpUtility.ParseQueryString(request.RequestUri.Query).Get("myData");
            if (string.IsNullOrEmpty(mydata))
            {
                HttpResponseMessage errorResponse =
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, "You must specify myData");
                throw new HttpResponseException(errorResponse);
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}