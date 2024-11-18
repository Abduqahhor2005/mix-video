using MixVideo.Common;
using MixVideo.Moduls.Video.Constants;

namespace MixVideo.Moduls.Video;

public class Video:BaseEntity
{
    public string Title { get; set; } = VideoNames.Default;
    public bool IsPaid { get; set; } 
    public string Description { get; set; } = null!;
    public decimal? Price { get; set; }

    public ICollection<Comment.Comment> Comments { get; set; } = [];
    public ICollection<Viewer.Viewer> Viewers { get; set; } = [];
}