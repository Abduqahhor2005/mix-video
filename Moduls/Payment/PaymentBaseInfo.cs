namespace MixVideo.Moduls.Payment;

public readonly record struct PaymentBaseInfo(
    decimal Amount,
    DateTimeOffset PaymentDate,
    string PaymentMethod,
    int UserId, 
    int VideoId);