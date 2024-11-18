using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Comment.Repository.CommandRepository;

namespace MixVideo.Moduls.Comment.Commands.CommentCommandHandler;

public class DeleteCommentHandler(ICommentCommandRepository commentCommandRepository)
    :IRequestHandler<DeleteCommentRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Comment?> existingComments = await commentCommandRepository.FindAsync(x =>
            x.Id == request.Id);    
        Comment? existing = existingComments.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await commentCommandRepository.UpdateAsync(existing.ToDeletedComment());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Comment not deleted !!!"))
            : BaseResult.Success();
    }
}