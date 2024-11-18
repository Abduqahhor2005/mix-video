using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;

namespace MixVideo.Moduls.Viewer.Queries.ViewerQueryHandler;

public class GetViewersHandler(AppQueryDbContext context) : IRequestHandler<GetViewerViewModelRequest, Result<PagedResponse<IEnumerable<GetViewerViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetViewerViewModel>>>> Handle(GetViewerViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Viewer> viewers = context.Viewers;

        
        if (request.Filter!.ViewDate != null)
            viewers = viewers.Where(x => x.ViewDate==request.Filter.ViewDate);
        if (request.Filter!.IsPurchased != null)
            viewers = viewers.Where(x => x.IsPurchased==request.Filter.IsPurchased);
        if (request.Filter!.UserId != null)
            viewers = viewers.Where(x => x.UserId==request.Filter.UserId);
        if (request.Filter!.VideoId != null)
            viewers = viewers.Where(x => x.VideoId==request.Filter.VideoId);
        
        int count = await viewers.CountAsync(cancellationToken);

        IQueryable<GetViewerViewModel> result = viewers
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetViewerViewModel>> response = PagedResponse<IEnumerable<GetViewerViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetViewerViewModel>>>.Success(response);
    }
}