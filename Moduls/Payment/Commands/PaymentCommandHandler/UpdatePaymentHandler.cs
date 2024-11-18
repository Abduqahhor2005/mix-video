using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Payment.Repository.CommandRepository;

namespace MixVideo.Moduls.Payment.Commands.PaymentCommandHandler;

public class UpdatePaymentHandler(IPaymentCommandRepository paymentCommandRepository):IRequestHandler<UpdatePaymentRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdatePaymentRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Payment?> existingPayments = await paymentCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Payment payment = existingPayments.FirstOrDefault()!;
        if (payment is null) return BaseResult.Failure(Error.None());

        int res = await paymentCommandRepository.UpdateAsync(payment.ToUpdatedPayment(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Payment not updated !!!"))
            : BaseResult.Success();
    }
}