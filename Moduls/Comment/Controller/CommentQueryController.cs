using MediatR;
using Microsoft.AspNetCore.Mvc;
using MixVideo.Common;
using MixVideo.Common.Extensions;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;
using MixVideo.Moduls.Comment.Queries;

namespace MixVideo.Moduls.Comment.Controller;

[Route("/api/comments")]
public class CommentQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] CommentFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetCommentViewModel>>> response = await sender.Send(new GetCommentViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetCommentDetailViewModel> response = await sender.Send(new GetCommentDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}