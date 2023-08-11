using Moq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthenticatedSchoolSystem.Back_End.HTTP
{
    public static class MyHttpContext
    {
        public static void SetMyContext(this Controller controller)
        {
            Mock<HttpContextBase> Context = new Mock<HttpContextBase>();
            Mock<HttpRequestBase> Request = new Mock<HttpRequestBase>();
            Mock<HttpResponseBase> Response = new Mock<HttpResponseBase>();
            Mock<HttpSessionStateBase> Session = new Mock<HttpSessionStateBase>();
            Mock<HttpServerUtilityBase> Server = new Mock<HttpServerUtilityBase>();
            Mock<IPrincipal> User = new Mock<IPrincipal>();
            Mock<IIdentity> Identity = new Mock<IIdentity>();

            _ = Context.Setup(c => c.Request).Returns(Request.Object);
            _ = Context.Setup(c => c.Response).Returns(Response.Object);
            _ = Context.Setup(c => c.Session).Returns(Session.Object);
            _ = Context.Setup(c => c.Server).Returns(Server.Object);
            _ = Context.Setup(c => c.User).Returns(User.Object);
            _ = User.Setup(c => c.Identity).Returns(Identity.Object);
            _ = Identity.Setup(i => i.IsAuthenticated).Returns(true);
            _ = Identity.Setup(i => i.Name).Returns("myUserName");

            controller.ControllerContext =
                new ControllerContext(new RequestContext(Context.Object, new RouteData()), controller);
        }
    }
}