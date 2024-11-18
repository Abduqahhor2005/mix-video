using MediatR;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.User.Commands;

public readonly record struct CreateUserRequest(
    UserBaseInfo UserBaseInfo):IRequest<BaseResult>;
    
public readonly record struct UpdateUserRequest(
    int Id,
    UserBaseInfo UserBaseInfo):IRequest<BaseResult>;    
  
public readonly record struct DeleteUserRequest(int Id):IRequest<BaseResult>;