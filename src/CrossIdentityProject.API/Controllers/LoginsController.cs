using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public LoginsController(SignInManager<AppUser> signInManager,
               UserManager<AppUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost()]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password,isPersistent: false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                var user_info = await userManager.FindByNameAsync(model.Username);

                var name = user_info!.Name;

                return Ok($"Login successful + {name}");
            }

            return Unauthorized("Invalid login attempt");
        }

    }
}
