using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices;
using CrossIdentityProject.API.Services.IdentityServices.TwoFactorLoginIdentityServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginIdentityService loginIdentityService;
        private readonly ITwoFactorLoginIdentityService twoFactorLoginIdentityService;

        public LoginsController(ILoginIdentityService loginIdentityService,ITwoFactorLoginIdentityService twoFactorLoginIdentityService)
        {
            this.loginIdentityService = loginIdentityService;
            this.twoFactorLoginIdentityService = twoFactorLoginIdentityService;
        }

        [HttpPost()]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            return Ok(await loginIdentityService.LoginAsync(model));
        }

        [HttpPost("VerifyTwoFactorAuthentication")]
        public async Task<IActionResult> VerifyTwoFactorAuthentication([FromBody] TwoFactorLoginModel model)
        {
            return Ok(await twoFactorLoginIdentityService.TwoFactorLoginAsync(model));
        }
    }

}

