using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Comment.Repository.CommandRepository;

namespace MixVideo.Moduls.Comment.Commands.CommentCommandHandler;

public class UpdateCommentHandler(ICommentCommandRepository commentCommandRepository):IRequestHandler<UpdateCommentRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateCommentRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Comment?> existingComments = await commentCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Comment comment = existingComments.FirstOrDefault()!;
        if (comment is null) return BaseResult.Failure(Error.None());

        int res = await commentCommandRepository.UpdateAsync(comment.ToUpdatedComment(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Comment not updated !!!"))
            : BaseResult.Success();
    }
}