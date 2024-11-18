using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;

namespace MixVideo.Moduls.Viewer.Queries;

public readonly record struct GetViewerViewModel(
    int Id,
    ViewerBaseInfo ViewerBaseInfo);

public record GetViewerViewModelRequest(ViewerFilter? Filter) : IRequest<Result<PagedResponse<IEnumerable<GetViewerViewModel>>>>;

public readonly record struct GetViewerDetailViewModel(
    int Id,
    ViewerBaseInfo ViewerBaseInfo);
    
public record GetViewerDetailViewModelRequest(int Id) : IRequest<Result<GetViewerDetailViewModel>>;