using MixVideo.Common;

namespace MixVideo.Moduls.Comment;

public record CommentFilter(
    string? Text, 
    DateTimeOffset? CreatedAt, 
    int? UserId, 
    int? VideoId):BaseFilter;