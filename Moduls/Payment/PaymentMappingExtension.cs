using MixVideo.Moduls.Payment.Commands;
using MixVideo.Moduls.Payment.Queries;

namespace MixVideo.Moduls.Payment;

public static class PaymentMappingExtension
{
    public static GetPaymentViewModel ToReadInfo(this Payment payment)
    {
        return new()
        {
            Id = payment.Id,
            PaymentBaseInfo = new()
            {
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                UserId = payment.UserId,
                VideoId = payment.VideoId
            }
        };
    }
    
    public static GetPaymentDetailViewModel ToReadDetailInfo(this Payment payment)
    {
        return new()
        {
            Id = payment.Id,
            PaymentBaseInfo = new()
            {
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                UserId = payment.UserId,
                VideoId = payment.VideoId
            }
        };
    }

    public static Payment ToPayment(this CreatePaymentRequest request)
    {
        return new()
        {
            Amount = request.PaymentBaseInfo.Amount,
            PaymentDate = request.PaymentBaseInfo.PaymentDate,
            PaymentMethod = request.PaymentBaseInfo.PaymentMethod,
            UserId = request.PaymentBaseInfo.UserId,
            VideoId = request.PaymentBaseInfo.VideoId
        };
    }

    public static Payment ToUpdatedPayment(this Payment payment, UpdatePaymentRequest request)
    {
        payment.Version++;
        payment.UpdatedAt = DateTime.UtcNow;
        payment.Amount = request.PaymentBaseInfo.Amount;
        payment.PaymentDate = request.PaymentBaseInfo.PaymentDate;
        payment.PaymentMethod = request.PaymentBaseInfo.PaymentMethod;
        payment.UserId = request.PaymentBaseInfo.UserId;
        payment.VideoId = request.PaymentBaseInfo.VideoId;
        return payment;
    }

    public static Payment ToDeletedPayment(this Payment payment)
    {
        payment.IsDeleted = true;
        payment.DeletedAt = DateTime.UtcNow;
        payment.UpdatedAt = DateTime.UtcNow;
        payment.Version++;
        return payment;
    }
}