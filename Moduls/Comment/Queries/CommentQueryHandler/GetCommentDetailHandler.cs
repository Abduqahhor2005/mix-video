using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Comment.Queries.CommentQueryHandler;

public class GetCommentDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetCommentDetailViewModelRequest, Result<GetCommentDetailViewModel>>
{
    public async Task<Result<GetCommentDetailViewModel>> Handle(GetCommentDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Comment? result = await context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetCommentDetailViewModel>.Failure(Error.NotFound())
            : Result<GetCommentDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}