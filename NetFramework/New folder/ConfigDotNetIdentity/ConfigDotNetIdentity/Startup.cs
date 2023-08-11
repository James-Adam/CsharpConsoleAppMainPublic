using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConfigDotNetIdentity.Startup))]
namespace ConfigDotNetIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
