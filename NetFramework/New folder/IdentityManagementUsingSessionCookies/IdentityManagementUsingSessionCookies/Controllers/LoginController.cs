using IdentityManagementUsingSessionCookies.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IdentityManagementUsingSessionCookies.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PerformLogin([Bind] User userdetails)
        {
            if ((!string.IsNullOrEmpty(userdetails.UserId)) && (!string.IsNullOrEmpty(userdetails.Password)))
            {
                if ((userdetails.UserId.Equals("admin") && userdetails.Password.Equals("admin")))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userdetails.UserId),
                    new Claim(ClaimTypes.Role, "User"),
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.Now.AddMinutes(10),
                    };

                    await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index");
        }
    }
}
