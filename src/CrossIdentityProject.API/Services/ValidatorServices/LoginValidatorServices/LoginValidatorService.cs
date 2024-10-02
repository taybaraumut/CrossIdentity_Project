using CrossIdentityProject.API.Models.IdentityModels;
using FluentValidation;
using FluentValidation.Results;
namespace CrossIdentityProject.API.Services.ValidatorServices.LoginValidatorServices
{
    public class LoginValidatorService : ILoginValidatorService
    {
        private readonly IValidator<LoginModel> validator;

        public LoginValidatorService(IValidator<LoginModel> validator)
        {
            this.validator = validator;
        }
        public ValidationResult Validate(LoginModel model)
        {
            return validator.Validate(model);
        }
    }
}
