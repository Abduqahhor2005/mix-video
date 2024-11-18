using FluentValidation;

namespace MixVideo.Moduls.Comment;

public class CommentValidator:AbstractValidator<Comment>
{
    public CommentValidator()
    {
        RuleFor(x=>x.Text)
            .NotEmpty().WithMessage("Text is required.")
            .Length(2, 200).WithMessage("Text must be between 2 and 200 characters.");
        
        RuleFor(chat => chat.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(chat => chat.VideoId)
            .NotEmpty().WithMessage("VideoId is required.");
    }
}