using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AuthenticationLogin.Startup))]
namespace AuthenticationLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
