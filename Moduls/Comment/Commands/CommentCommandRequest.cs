using MediatR;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Comment.Commands;

public readonly record struct CreateCommentRequest(
    CommentBaseInfo CommentBaseInfo):IRequest<BaseResult>;
    
public readonly record struct UpdateCommentRequest(
    int Id,
    CommentBaseInfo CommentBaseInfo):IRequest<BaseResult>;    
  
public readonly record struct DeleteCommentRequest(int Id):IRequest<BaseResult>;  