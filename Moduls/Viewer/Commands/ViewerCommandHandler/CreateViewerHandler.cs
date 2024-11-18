using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Viewer.Repository.CommandRepository;

namespace MixVideo.Moduls.Viewer.Commands.ViewerCommandHandler;

public class CreateViewerHandler(IViewerCommandRepository viewerCommandRepository):IRequestHandler<CreateViewerRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateViewerRequest request, CancellationToken cancellationToken)
    {
        if (request==null)
            return BaseResult.Failure(Error.None());
        int res = await viewerCommandRepository.AddAsync(request.ToViewer());

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Viewer not saved !!!"))
            : BaseResult.Success();
    }
}