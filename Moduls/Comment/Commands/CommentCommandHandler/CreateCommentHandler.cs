using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Comment.Repository.CommandRepository;

namespace MixVideo.Moduls.Comment.Commands.CommentCommandHandler;

public class CreateCommentHandler(ICommentCommandRepository commentCommandRepository):IRequestHandler<CreateCommentRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
    {
        if (request==null)
            return BaseResult.Failure(Error.None());
        int res = await commentCommandRepository.AddAsync(request.ToComment());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Comment not saved !!!"))
            : BaseResult.Success();
    }
}