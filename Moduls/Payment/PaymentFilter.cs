using MixVideo.Common;

namespace MixVideo.Moduls.Payment;

public record PaymentFilter(
    decimal? Amount,
    DateTimeOffset? PaymentDate,
    string? PaymentMethod,
    int? UserId, 
    int? VideoId):BaseFilter;