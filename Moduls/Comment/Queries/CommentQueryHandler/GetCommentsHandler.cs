using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;

namespace MixVideo.Moduls.Comment.Queries.CommentQueryHandler;

public class GetCommentsHandler(AppQueryDbContext context) : IRequestHandler<GetCommentViewModelRequest, Result<PagedResponse<IEnumerable<GetCommentViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetCommentViewModel>>>> Handle(GetCommentViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Comment> comments = context.Comments;

        if (request.Filter!.Text != null)
            comments = comments.Where(x => x.Text.ToLower()
                .Contains(request.Filter.Text.ToLower()));
        if (request.Filter!.UserId != null)
            comments = comments.Where(x => x.UserId==request.Filter.UserId);
        if (request.Filter!.VideoId != null)
            comments = comments.Where(x => x.VideoId==request.Filter.VideoId);

        int count = await comments.CountAsync(cancellationToken);

        IQueryable<GetCommentViewModel> result = comments
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetCommentViewModel>> response = PagedResponse<IEnumerable<GetCommentViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetCommentViewModel>>>.Success(response);
    }
}