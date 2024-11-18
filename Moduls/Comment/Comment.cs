using MixVideo.Common;

namespace MixVideo.Moduls.Comment;

public class Comment:BaseEntity
{
    public string Text { get; set; } = null!;
    public int UserId { get; set; } 
    public int VideoId { get; set; } 
    
    public User.User User { get; set; } = null!;
    public Video.Video Video { get; set; } = null!;
}