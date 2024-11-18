using FluentValidation;

namespace MixVideo.Moduls.Viewer;

public class ViewerValidator:AbstractValidator<Viewer>
{
    public ViewerValidator()
    {
        RuleFor(chat => chat.ViewDate)
            .NotEmpty().WithMessage("ViewDate is required.");

        RuleFor(chat => chat.IsPurchased)
            .NotEmpty().WithMessage("IsPurchased is required.");
        
        RuleFor(chat => chat.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(chat => chat.VideoId)
            .NotEmpty().WithMessage("VideoId is required.");
    }
}