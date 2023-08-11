namespace CsharpConsoleAppMain._5.DevMicroAzureAndWebService.MiddleWare;

public class UserKeyValidatorsMiddleware
{
    private readonly RequestDelegate _next;

    public UserKeyValidatorsMiddleware(IContactsRepository contactsRepo, RequestDelegate next)
    {
        _next = next;
        ContactsRepo = contactsRepo;
    }

    private IContactsRepository ContactsRepo { get; }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Headers.Keys.Contains("user-key"))
        {
            context.Response.StatusCode = 400; //bad request
            await context.Response.WriteAsync("User key is missing");
            return;
        }

        if (!ContactsRepo.CheckValidUserKey(context.Request.Headers["user-key"]))
        {
            context.Response.StatusCode = 401;
            //unauthorized
            await context.Response.WriteAsync("Invalid User Key");
            return;
        }

        await _next.Invoke(context);
    }
}

#region ExtensionMethod

public static class UserKeyValidatorsExtension
{
    public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
    {
        _ = app.UseMiddleware<UserKeyValidatorsMiddleware>();
        return app;
    }
}

#endregion ExtensionMethod