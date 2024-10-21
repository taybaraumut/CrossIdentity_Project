using CrossIdentityProject.API.Models.EmailVerificationModels;
using CrossIdentityProject.API.Services.EmailVerificationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrossIdentityProject.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailVerificationsController : ControllerBase
    {
        private readonly IEmailMemberVerificationService emailVerificationService;

        public EmailVerificationsController(IEmailMemberVerificationService emailVerificationService)
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
