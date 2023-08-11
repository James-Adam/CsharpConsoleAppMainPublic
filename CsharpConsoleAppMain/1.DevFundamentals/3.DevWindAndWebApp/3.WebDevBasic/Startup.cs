namespace CsharpConsoleAppMain;

//"WindFormsApplications: 1"
public class Startup
{
    public void ConfigurationServices(IServiceCollection service)
    {
        // Method intentionally left empty.
    }

    public void Configure(IApplicationBuilder application, IWebHostEnvironment environment)
    {
        _ = application.UseRouting();

        _ = application.UseEndpoints(endpoints =>
        {
            _ = endpoints.MapGet("/", async context => await context.Response.WriteAsync("Hello World"));
        });
    }
}