using CrossIdentityProject.UI.Models.IdentityViewModels;
using FluentValidation;

namespace CrossIdentityProject.UI.ValidationRules.IdentityValidationRules
{
    public class RegisterValidator:AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("ad boş geçilemez")
                .MinimumLength(2).WithMessage("ad en az 2 karakter olabilir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("soyad boş geçilemez")
                .MinimumLength(2).WithMessage("soyad en az 2 karakter olabilir");

            RuleFor(x => x.Username)
                .NotNull().WithMessage("kullanıcı adı boş geçilemez")
                .MinimumLength(6).WithMessage("kullanıcı adı en az 6 karakter olabilir")
                .MaximumLength(15).WithMessage("kullanıcı adı en fazla 15 karakter olabilir");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("email boş geçilemez")
                .EmailAddress().WithMessage("email formatında giriniz lütfen");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("şehir boş geçilemez");

            RuleFor(x => x.District)
                .NotEmpty().WithMessage("ilçe boş geçilemez");

            RuleFor(x => x.Password).NotNull().WithMessage("şifre boş geçilemez")
                .MinimumLength(10).WithMessage("şifre en az 10 karakter olabilir")
                .MaximumLength(25).WithMessage("şifre en fazla 25 karakter olabilir");

            RuleFor(x => x.ConfirmPassword).NotNull().WithMessage("şifre tekrar boş geçilemez")
                .MinimumLength(10).WithMessage("şifre tekrar en az 10 karakter olabilir")
                .MaximumLength(25).WithMessage("şifre tekrar en fazla 25 karakter olabilir");
        }
    }
}
