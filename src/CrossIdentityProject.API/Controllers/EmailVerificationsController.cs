using CrossIdentityProject.API.Models.EmailVerificationModels;
using CrossIdentityProject.API.Services.EmailVerificationServices;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailVerificationsController : ControllerBase
    {
        private readonly IEmailVerificationService emailVerificationService;

        public EmailVerificationsController(IEmailVerificationService emailVerificationService)
        {
            this.emailVerificationService = emailVerificationService;
        }

        [HttpPost()]
        public async Task<IActionResult> ConfirmEmail(VerificationModel model)
        {
            return Ok(await emailVerificationService.ConfirmEmailAsync(model));
        }
    }
}
