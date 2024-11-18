using MediatR;
using Microsoft.AspNetCore.Mvc;
using MixVideo.Common;
using MixVideo.Common.Extensions;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;
using MixVideo.Moduls.Payment.Queries;

namespace MixVideo.Moduls.Payment.Controller;

[Route("/api/payments")]
public class PaymentQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PaymentFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetPaymentViewModel>>> response = await sender.Send(new GetPaymentViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetPaymentDetailViewModel> response = await sender.Send(new GetPaymentDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}