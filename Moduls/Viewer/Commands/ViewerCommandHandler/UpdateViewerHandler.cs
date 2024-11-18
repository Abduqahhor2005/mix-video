using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Viewer.Repository.CommandRepository;

namespace MixVideo.Moduls.Viewer.Commands.ViewerCommandHandler;

public class UpdateViewerHandler(IViewerCommandRepository viewerCommandRepository):IRequestHandler<UpdateViewerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(UpdateViewerRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Viewer?> existingViewers = await viewerCommandRepository.FindAsync(x=>
            x.Id==request.Id);
        Viewer viewer = existingViewers.FirstOrDefault()!;
        if (viewer is null) return BaseResult.Failure(Error.None());

        int res = await viewerCommandRepository.UpdateAsync(viewer.ToUpdatedViewer(request));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Viewer not updated !!!"))
            : BaseResult.Success();
    }
}