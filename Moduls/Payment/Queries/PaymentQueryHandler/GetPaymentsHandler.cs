using MediatR;
using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Data;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;

namespace MixVideo.Moduls.Payment.Queries.PaymentQueryHandler;

public class GetPaymentsHandler(AppQueryDbContext context) : IRequestHandler<GetPaymentViewModelRequest, Result<PagedResponse<IEnumerable<GetPaymentViewModel>>>>
{
    public async Task<Result<PagedResponse<IEnumerable<GetPaymentViewModel>>>> Handle(GetPaymentViewModelRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Payment> payments = context.Payments;

        if (request.Filter!.Amount != null)
            payments = payments.Where(x => x.Amount==request.Filter.Amount);
        if (request.Filter!.PaymentDate != null)
            payments = payments.Where(x => x.PaymentDate==request.Filter.PaymentDate);
        if (request.Filter!.PaymentMethod != null)
            payments = payments.Where(x => x.PaymentMethod.ToLower()
                .Contains(request.Filter.PaymentMethod.ToLower()));
        if (request.Filter!.UserId != null)
            payments = payments.Where(x => x.UserId==request.Filter.UserId);
        if (request.Filter!.VideoId != null)
            payments = payments.Where(x => x.VideoId==request.Filter.VideoId);

        int count = await payments.CountAsync(cancellationToken);

        IQueryable<GetPaymentViewModel> result = payments
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize).Select(x => x.ToReadInfo());


        PagedResponse<IEnumerable<GetPaymentViewModel>> response = PagedResponse<IEnumerable<GetPaymentViewModel>>
            .Create(request.Filter.PageNumber, request.Filter.PageSize, count, result);

        return Result<PagedResponse<IEnumerable<GetPaymentViewModel>>>.Success(response);
    }
}