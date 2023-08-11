using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//IdentityManagement using session cookies

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Login/UserLogin/";
                });
builder.Services.AddMvc();

var app = builder.Build();
app.UseAuthentication();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    app.UseDeveloperExceptionPage();
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
    {
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");
});
app.UseRouting();

app.UseAuthorization();


app.Run();
