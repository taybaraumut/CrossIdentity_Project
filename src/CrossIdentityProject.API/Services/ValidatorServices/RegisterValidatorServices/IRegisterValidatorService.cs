using CrossIdentityProject.API.Models.IdentityModels;
using FluentValidation.Results;

namespace CrossIdentityProject.API.Services.ValidatorServices.RegisterValidatorServices
{
    public interface IRegisterValidatorService
    {
        public ValidationResult Validate(RegisterModel model);
    }
}
