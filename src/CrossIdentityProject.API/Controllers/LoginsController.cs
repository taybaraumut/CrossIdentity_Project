using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.LoginIdentityServices;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginIdentityService loginIdentityService;

        public LoginsController(ILoginIdentityService loginIdentityService)
        {
            this.loginIdentityService = loginIdentityService;
        }

        [HttpPost()]
        public async Task<IActionResult> SignIn([FromBody] LoginModel model)
        {
            return Ok(await loginIdentityService.LoginAsync(model));
        }

    }

}

