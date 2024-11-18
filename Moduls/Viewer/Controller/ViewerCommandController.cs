using MediatR;
using Microsoft.AspNetCore.Mvc;
using MixVideo.Common;
using MixVideo.Common.Extensions;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Viewer.Commands;

namespace MixVideo.Moduls.Viewer.Controller;

[Route("/api/viewers")]
public class ViewerCommandController(ISender sender):BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateViewerRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateViewerRequest entity)
    {
        BaseResult result = await sender.Send(entity);
        return result.ToActionResult();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        BaseResult result = await sender.Send(new DeleteViewerRequest(id));
        return result.ToActionResult();
    }
}