using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Viewer.Queries.ViewerQueryHandler;

public class GetViewerDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetViewerDetailViewModelRequest, Result<GetViewerDetailViewModel>>
{
    public async Task<Result<GetViewerDetailViewModel>> Handle(GetViewerDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Viewer? result = await context.Viewers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetViewerDetailViewModel>.Failure(Error.NotFound())
            : Result<GetViewerDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}