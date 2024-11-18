using MediatR;
using Microsoft.AspNetCore.Mvc;
using MixVideo.Common;
using MixVideo.Common.Extensions;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;
using MixVideo.Moduls.Video.Queries;

namespace MixVideo.Moduls.Video.Controller;

[Route("/api/videos")]
public class VideoQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] VideoFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetVideoViewModel>>> response = await sender.Send(new GetVideoViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetVideoDetailViewModel> response = await sender.Send(new GetVideoDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}