using CrossIdentityProject.API.Models.IdentityModels;
using FluentValidation;
using FluentValidation.Results;

namespace CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices
{
    public class RegisterValidatorService : IRegisterValidatorService
    {
        private readonly IValidator<RegisterModel> validator;

        public RegisterValidatorService(IValidator<RegisterModel> validator)
        {
            this.validator = validator;
        }
        public ValidationResult Validate(RegisterModel model)
        {
            return validator.Validate(model);
        }
    }
}
