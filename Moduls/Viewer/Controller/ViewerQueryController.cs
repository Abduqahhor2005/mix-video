using MediatR;
using Microsoft.AspNetCore.Mvc;
using MixVideo.Common;
using MixVideo.Common.Extensions;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;
using MixVideo.Moduls.Viewer.Queries;

namespace MixVideo.Moduls.Viewer.Controller;

[Route("/api/viewers")]
public class ViewerQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ViewerFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetViewerViewModel>>> response = await sender.Send(new GetViewerViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetViewerDetailViewModel> response = await sender.Send(new GetViewerDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}