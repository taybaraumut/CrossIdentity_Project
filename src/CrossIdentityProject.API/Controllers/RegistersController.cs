using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IRegisterIdentityService registerIdentityService;

        public RegistersController(IRegisterIdentityService registerIdentityService)
        {
            this.registerIdentityService = registerIdentityService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel model)
        {
            return Ok(await registerIdentityService.RegisterAsync(model));
        }
    }
}
