using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace CsharpConsoleAppMain._5.DevMicroAzureAndWebService.MiddleWare;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddMvc();
    }

    [Obsolete]
    public void Configure(IApplicationBuilder app,
        IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        _ = loggerFactory.CreateLogger("");
        //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        //loggerFactory.AddDebug();

        _ = app.ApplyUserKeyValidation();
        _ = app.UseMvc();
    }
}