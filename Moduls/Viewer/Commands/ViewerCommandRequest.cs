using MediatR;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Viewer.Commands;

public readonly record struct CreateViewerRequest(
    ViewerBaseInfo ViewerBaseInfo):IRequest<BaseResult>;
    
public readonly record struct UpdateViewerRequest(
    int Id,
    ViewerBaseInfo ViewerBaseInfo):IRequest<BaseResult>;    
  
public readonly record struct DeleteViewerRequest(int Id):IRequest<BaseResult>;