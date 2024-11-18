using MediatR;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Video.Commands;

public readonly record struct CreateVideoRequest(
    VideoBaseInfo VideoBaseInfo):IRequest<BaseResult>;
    
public readonly record struct UpdateVideoRequest(
    int Id,
    VideoBaseInfo VideoBaseInfo):IRequest<BaseResult>;    
  
public readonly record struct DeleteVideoRequest(int Id):IRequest<BaseResult>;