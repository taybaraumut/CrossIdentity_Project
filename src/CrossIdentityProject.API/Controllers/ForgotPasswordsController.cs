using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.IdentityServices.ForgotPasswordServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordsController : ControllerBase
    {
        private readonly IForgotPasswordService forgotPasswordService;

        public ForgotPasswordsController(IForgotPasswordService forgotPasswordService)
        {
            this.forgotPasswordService = forgotPasswordService;
        }

        [HttpPost("GetPassword")]
        public async Task<IActionResult> GetPassword([FromBody] ResetPasswordEmailModel model)
        {
            return Ok(await forgotPasswordService.PasswordResetTokenAsync(model));
        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
        {
            var result = await forgotPasswordService.VerifyPasswordResetTokenAsync(model);

            if (result == true)
            {
                return Ok("Success");
            }
            return BadRequest();
        }
    }
}
