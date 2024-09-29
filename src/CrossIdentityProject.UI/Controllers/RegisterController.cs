using CrossIdentityProject.UI.Models.IdentityViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace CrossIdentityProject.UI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			this.httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public IActionResult SignUp()
        {
			return View();
        }

		[ValidateAntiForgeryToken]
		[HttpPost]
		public async Task<IActionResult> SignUp(RegisterViewModel model)
		{
			var client = httpClientFactory.CreateClient();
			var response = await client.PostAsJsonAsync("https://localhost:44357/api/Registers", model);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("SignIn", "Login");
			}
			return View();
		}
	}
}
