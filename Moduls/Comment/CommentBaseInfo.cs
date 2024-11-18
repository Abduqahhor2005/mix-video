namespace MixVideo.Moduls.Comment;

public readonly record struct CommentBaseInfo(
    string Text, 
    DateTimeOffset CreatedAt, 
    int UserId, 
    int VideoId);