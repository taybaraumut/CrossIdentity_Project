using CrossIdentityProject.UI.Models.IdentityViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

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
					new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Username) }, CookieAuthenticationDefaults.AuthenticationScheme)));
				
				return RedirectToAction("SignUp", "Register");
			}

			ModelState.AddModelError(string.Empty, "Geçersiz giriş.");
			return View(model);
		}
	}
}
