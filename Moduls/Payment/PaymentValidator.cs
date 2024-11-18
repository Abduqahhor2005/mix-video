using FluentValidation;

namespace MixVideo.Moduls.Payment;

public class PaymentValidator:AbstractValidator<Payment>
{
    public PaymentValidator()
    {
        RuleFor(chat => chat.Amount)
            .NotEmpty().WithMessage("Amount is required.");

        RuleFor(chat => chat.PaymentDate)
            .NotEmpty().WithMessage("PaymentDate is required.");
        
        RuleFor(x=>x.PaymentMethod)
            .NotEmpty().WithMessage("PaymentMethod is required.")
            .Length(2, 20).WithMessage("PaymentMethod must be between 2 and 20 characters.");
        
        RuleFor(chat => chat.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(chat => chat.VideoId)
            .NotEmpty().WithMessage("VideoId is required.");
    }
}