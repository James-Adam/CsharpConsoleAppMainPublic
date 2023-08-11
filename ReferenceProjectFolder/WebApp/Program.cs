namespace WebApp;

public static class Program
{
    /// <summary>
    ///     The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
        var builder = WebApplication.CreateBuilder();

        // Add services to the container.
        _ = builder.Services.AddRazorPages();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            _ = app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production
            // scenarios, see https://aka.ms/aspnetcore-hsts.
            _ = app.UseHsts();
        }

        _ = app.UseHttpsRedirection();
        _ = app.UseStaticFiles();

        _ = app.UseRouting();

        _ = app.UseAuthorization();

        _ = app.MapRazorPages();
        Console.WriteLine("Hello World");
        app.Run();
    }
}