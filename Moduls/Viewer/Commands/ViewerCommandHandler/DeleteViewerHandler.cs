using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Viewer.Repository.CommandRepository;

namespace MixVideo.Moduls.Viewer.Commands.ViewerCommandHandler;

public class DeleteViewerHandler(IViewerCommandRepository viewerCommandRepository)
    :IRequestHandler<DeleteViewerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteViewerRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Viewer?> existingViewers = await viewerCommandRepository.FindAsync(x =>
            x.Id == request.Id);    
        Viewer? existing = existingViewers.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await viewerCommandRepository.UpdateAsync(existing.ToDeletedViewer());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Viewer not deleted !!!"))
            : BaseResult.Success();
    }
}