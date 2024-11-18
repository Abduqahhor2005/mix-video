using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.User.Queries.UserQueryHandler;

public class GetUserDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetUserDetailViewModelRequest, Result<GetUserDetailViewModel>>
{
    public async Task<Result<GetUserDetailViewModel>> Handle(GetUserDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        User? result = await context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetUserDetailViewModel>.Failure(Error.NotFound())
            : Result<GetUserDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}