using MixVideo.Common;

namespace MixVideo.Moduls.Viewer;

public class Viewer:BaseEntity
{
    public DateTime ViewDate { get; set; }
    public bool IsPurchased { get; set; }
    
    public int UserId { get; set; }
    public int VideoId { get; set; }

    public User.User User { get; set; } = null!;
    public Video.Video Video { get; set; } = null!;
}