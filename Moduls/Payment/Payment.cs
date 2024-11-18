using MixVideo.Common;

namespace MixVideo.Moduls.Payment;

public class Payment:BaseEntity
{
    public decimal Amount { get; set; } 
    public DateTimeOffset PaymentDate { get; set; } 
    public string PaymentMethod { get; set; } = null!;
    public int UserId { get; set; } 
    public int VideoId { get; set; } 
    
    public User.User User { get; set; } = null!;
    public Video.Video Video { get; set; } = null!;
}