using CrossIdentityProject.UI.Models.IdentityViewModels;
using Microsoft.AspNetCore.Mvc;

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
                var email = await response.Content.ReadAsStringAsync();

				return RedirectToAction("EmailConfimation", "EmailVerification", new { email = email});
			}
			return View();
		}
    }
}
