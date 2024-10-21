using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using CrossIdentityProject.API.Services.LogServices;
using CrossIdentityProject.API.Services.RandomCodeServices;
using CrossIdentityProject.API.Services.SendMailServices.RegistrationVerificationEmailSendingServices;
using CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace CrossIdentityProject.API.Services.IdentityServices.RegisterIdentityServices
{
    public class RegisterIdentityService : IRegisterIdentityService
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IRegisterValidatorService registerValidatorService;
        private readonly IRegistrationVerificationEmailSendingService sendMailService;
        private readonly IRandomCodeService randomCodeService;
        private readonly ILogService logService;

        public RegisterIdentityService(UserManager<AppUser> userManager,
               IRegisterValidatorService registerValidatorService,
               ILogService logService,
               IRegistrationVerificationEmailSendingService sendMailService,
               IRandomCodeService randomCodeService)
        {
            this.userManager = userManager;
            this.registerValidatorService = registerValidatorService;
            this.logService = logService;
            this.sendMailService = sendMailService;
            this.randomCodeService = randomCodeService;
        }
        public async Task<string> RegisterAsync(RegisterModel model)
        {
            var random_code = randomCodeService.GetCode();

            AppUser user = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.Username,
                Email = model.Email,
                City = model.City,
                District = model.District,
                Code = random_code,
            };

            var create_user = await userManager.CreateAsync(user, model.Password);

            if (create_user.Succeeded)
            {
                sendMailService.RegistrationVerificationEmailSend(user.Email,user.Name,user.UserName,(ushort)user.Code);

                logService.Register_Sucess_Logger(user.Name, user.Surname, user.Email, user.UserName, user.District, user.City);
                return model.Email;
            }
            else
            {
                return JsonConvert.SerializeObject("Registration Failed");
            }
               
        }
    }
}
