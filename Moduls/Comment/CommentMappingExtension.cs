using MixVideo.Moduls.Comment.Commands;
using MixVideo.Moduls.Comment.Queries;

namespace MixVideo.Moduls.Comment;

public static class CommentMappingExtension
{
    public static GetCommentViewModel ToReadInfo(this Comment comment)
    {
        return new()
        {
            Id = comment.Id,
            CommentBaseInfo = new()
            {
                Text = comment.Text,
                CreatedAt = comment.CreatedAt,
                UserId = comment.UserId,
                VideoId = comment.VideoId
            }
        };
    }
    
    public static GetCommentDetailViewModel ToReadDetailInfo(this Comment comment)
    {
        return new()
        {
            Id = comment.Id,
            CommentBaseInfo = new()
            {
                Text = comment.Text,
                CreatedAt = comment.CreatedAt,
                UserId = comment.UserId,
                VideoId = comment.VideoId
            }
        };
    }

    public static Comment ToComment(this CreateCommentRequest request)
    {
        return new()
        {
            Text = request.CommentBaseInfo.Text,
            CreatedAt = request.CommentBaseInfo.CreatedAt,
            UserId = request.CommentBaseInfo.UserId,
            VideoId = request.CommentBaseInfo.VideoId
        };
    }

    public static Comment ToUpdatedComment(this Comment comment, UpdateCommentRequest request)
    {
        comment.Version++;
        comment.UpdatedAt = DateTime.UtcNow;
        comment.Text = request.CommentBaseInfo.Text;
        comment.CreatedAt = request.CommentBaseInfo.CreatedAt;
        comment.UserId = request.CommentBaseInfo.UserId;
        comment.VideoId = request.CommentBaseInfo.VideoId;
        return comment;
    }

    public static Comment ToDeletedComment(this Comment comment)
    {
        comment.IsDeleted = true;
        comment.DeletedAt = DateTime.UtcNow;
        comment.UpdatedAt = DateTime.UtcNow;
        comment.Version++;
        return comment;
    }
}