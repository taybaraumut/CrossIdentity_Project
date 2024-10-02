using CrossIdentityProject.API.Entities;
using CrossIdentityProject.API.Models.IdentityModels;
using FluentValidation;

namespace CrossIdentityProject.API.ValidationRules.IdentityValidationRules
{
	public class LoginValidator:AbstractValidator<LoginModel>
	{
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez");
        }
    }
}
