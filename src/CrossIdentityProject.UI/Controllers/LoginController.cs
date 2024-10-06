using CrossIdentityProject.UI.Models.IdentityViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CrossIdentityProject.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient httpClient;

        public LoginController(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            var response = await httpClient.PostAsJsonAsync("https://localhost:44357/api/Logins", model);

            if (response.IsSuccessStatusCode)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username!) }, CookieAuthenticationDefaults.AuthenticationScheme)));

                return RedirectToAction("SignUp", "Register");
            }
            return View(model);

        }
    }
}
