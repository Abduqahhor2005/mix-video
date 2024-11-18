using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;

namespace MixVideo.Moduls.Comment.Queries;

public readonly record struct GetCommentViewModel(
    int Id,
    CommentBaseInfo CommentBaseInfo);

public record GetCommentViewModelRequest(CommentFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetCommentViewModel>>>>;

public readonly record struct GetCommentDetailViewModel(
    int Id,
    CommentBaseInfo CommentBaseInfo);
    
public record GetCommentDetailViewModelRequest(int Id) : IRequest<Result<GetCommentDetailViewModel>>;