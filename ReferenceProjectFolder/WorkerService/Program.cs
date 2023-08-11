using Serilog;

//IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices(services =>
//    {
//        services.AddHostedService<Worker>();
//    })
//    .Build();

//await host.RunAsync();
namespace WorkerService;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
        //var configuration = new ConfigurationBuilder()
        //.SetBasePath(Directory.GetCurrentDirectory())
        //.AddJsonFile("appsettings.json")
        //.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        //.Build();

        // var logger = new LoggerConfiguration() .ReadFrom.Configuration(configuration) .CreateLogger();

        // logger.Information("Hello, world!");
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .UseSerilog()
            .ConfigureServices((hostContext, services) =>
            {
                Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(hostContext.Configuration)
                    .CreateLogger();
                _ = services.AddHttpClient();
                _ = services.AddHostedService<Worker>();
            });
    }
}