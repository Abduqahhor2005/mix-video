using MediatR;
using Microsoft.AspNetCore.Mvc;
using MixVideo.Common;
using MixVideo.Common.Extensions;
using MixVideo.Common.PatternResult;
using MixVideo.Common.Responses;
using MixVideo.Moduls.User.Queries;

namespace MixVideo.Moduls.User.Controller;

[Route("/api/users")]
public class UserQueryController(ISender sender) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] UserFilter filter)
    {
        Result<PagedResponse<IEnumerable<GetUserViewModel>>> response = await sender.Send(new GetUserViewModelRequest(filter));
        return response.ToActionResult();
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        Result<GetUserDetailViewModel> response = await sender.Send(new GetUserDetailViewModelRequest(id));
        return response.ToActionResult();
    }
}