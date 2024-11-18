using MixVideo.Common;

namespace MixVideo.Moduls.User;

public class User:BaseEntity
{
    public string FullName { get; set; } = null!;
    public int Age { get; set; }
    public string Email { get; set; } = null!;

    public ICollection<Payment.Payment> Payments { get; set; } = [];
    public ICollection<Viewer.Viewer> Viewers { get; set; } = [];
    public ICollection<Comment.Comment> Comments { get; set; } = [];
}