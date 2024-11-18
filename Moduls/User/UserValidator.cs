using FluentValidation;

namespace MixVideo.Moduls.User;

public class UserValidator:AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x=>x.FullName)
            .NotEmpty().WithMessage("FullName is required.")
            .Length(2, 20).WithMessage("FullName must be between 2 and 20 characters.");
        
        RuleFor(chat => chat.Age)
            .NotEmpty().WithMessage("Age is required.");

        RuleFor(chat => chat.Email)
            .NotEmpty().WithMessage("Email is required.")
            .Length(10, 30).WithMessage("Email must be between 10 and 30 characters.")
            .EmailAddress().WithMessage("Email is invalid! Please check!");
    }
}