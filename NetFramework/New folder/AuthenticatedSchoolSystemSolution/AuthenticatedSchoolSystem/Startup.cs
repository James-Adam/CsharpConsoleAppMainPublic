using AuthenticatedSchoolSystem;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Startup))]

namespace AuthenticatedSchoolSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            _ = app.MapSignalR();
        }

        //using signalR for Real time web
        public void SendInfo(string message)
        {
            // Method intentionally left empty.
        }
    }
}