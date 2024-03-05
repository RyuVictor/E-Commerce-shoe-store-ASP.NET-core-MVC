using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eCommerce.UI.Areas.Security.Controllers
{
    [Area("Security")]
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public async Task GoogleLogin()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties()
            {
                RedirectUri = Url.Action("GoogleResponse")
            });
        }
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
            var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim =>
            new
            {
                claim.Issuer,
                claim.OriginalIssuer,
                claim.Type,
                claim.Value
            });
            Console.WriteLine(User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value);
            HttpContext.Session.SetString("Admin", User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value);
            return RedirectToAction("Index", "Home", new {area = ""});
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
