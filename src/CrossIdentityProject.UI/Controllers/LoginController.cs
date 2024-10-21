using CrossIdentityProject.UI.Models.IdentityViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net.Http.Headers;
using CrossIdentityProject.UI.Services.GenerateJwtTokenServices;

namespace CrossIdentityProject.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IGenerateJwtTokenService generateJwtTokenService;

        public LoginController(IHttpClientFactory httpClientFactory, IGenerateJwtTokenService generateJwtTokenService)
        {
            this.httpClientFactory = httpClientFactory;
            this.generateJwtTokenService = generateJwtTokenService;
        }

        [HttpGet]
        public async Task<IActionResult> SignIn()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            var token = await generateJwtTokenService.JwtToken();

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await client.PostAsJsonAsync("https://localhost:44357/api/Logins", model);

            if (response.IsSuccessStatusCode)
            {
                if (await response.Content.ReadAsStringAsync() == "true")
                {
                    return RedirectToAction("TwoFactorSignIn",new {Username = model.Username});
                }
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username!) }, CookieAuthenticationDefaults.AuthenticationScheme)));

                return RedirectToAction("Index", "UserPanel");
            }

            ViewBag.LoginFailed = await response.Content.ReadAsStringAsync();

            return View();
        }
        [HttpGet]
        public IActionResult TwoFactorSignIn(string Username)
        {
            TempData["Username"] = Username;
            TempData.Keep("Username");

            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> TwoFactorSignIn(TwoFactorLoginViewModel model)
        {
            var token = await generateJwtTokenService.JwtToken();

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var response = await client.PostAsJsonAsync("https://localhost:44357/api/Logins/VerifyTwoFactorAuthentication", model);
            if(response.IsSuccessStatusCode)
            {
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username!) }, CookieAuthenticationDefaults.AuthenticationScheme)));

                return RedirectToAction("Index", "UserPanel");
            }

            TempData["ErrorMessage"] = "Girmiş Olduğunuz Kod Hatalı";

            return View();
        }
    }
}
