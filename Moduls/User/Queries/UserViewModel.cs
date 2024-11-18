using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;

namespace MixVideo.Moduls.User.Queries;

public readonly record struct GetUserViewModel(
    int Id,
    UserBaseInfo UserBaseInfo);

public record GetUserViewModelRequest(UserFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetUserViewModel>>>>;

public readonly record struct GetUserDetailViewModel(
    int Id,
    UserBaseInfo UserBaseInfo);
    
public record GetUserDetailViewModelRequest(int Id) : IRequest<Result<GetUserDetailViewModel>>;