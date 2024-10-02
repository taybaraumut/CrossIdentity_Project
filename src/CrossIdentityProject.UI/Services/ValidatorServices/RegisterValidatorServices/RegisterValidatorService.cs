using CrossIdentityProject.UI.Models.IdentityViewModels;
using FluentValidation;
using FluentValidation.Results;

namespace CrossIdentityProject.UI.Services.ValidatorServices.RegisterValidatorServices
{
    public class RegisterValidatorService : IRegisterValidatorService
    {
        private readonly IValidator<RegisterViewModel> validator;

        public RegisterValidatorService(IValidator<RegisterViewModel> validator)
        {
            this.validator = validator;
        }

        public ValidationResult Validate(RegisterViewModel model)
        {
            return validator.Validate(model);
        }
    }
}
