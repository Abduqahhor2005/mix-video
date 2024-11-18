using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;

namespace MixVideo.Moduls.Payment.Queries.PaymentQueryHandler;

public class GetPaymentDetailHandler(AppQueryDbContext context)
    : IRequestHandler<GetPaymentDetailViewModelRequest, Result<GetPaymentDetailViewModel>>
{
    public async Task<Result<GetPaymentDetailViewModel>> Handle(GetPaymentDetailViewModelRequest request, CancellationToken cancellationToken)
    {
        Payment? result = await context.Payments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        return result is null
            ? Result<GetPaymentDetailViewModel>.Failure(Error.NotFound())
            : Result<GetPaymentDetailViewModel>.Success(result.ToReadDetailInfo());
    }
}