using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Video.FileService;
using MixVideo.Moduls.Video.Repository.CommandRepository;

namespace MixVideo.Moduls.Video.Commands.VideoCommandHandler;

public class CreateVideoHandler(IFileService fileService,IVideoCommandRepository videoCommandRepository):IRequestHandler<CreateVideoRequest,BaseResult>
{
    public async Task<BaseResult> Handle(CreateVideoRequest request, CancellationToken cancellationToken)
    {
        bool existTitle =
            (await videoCommandRepository
                .FindAsync(x => x.Title.ToLower() == request.VideoBaseInfo.Title
                    .ToLower())).Any();
        if (existTitle) 
            return BaseResult.Failure(Error.AlreadyExist());
        int res = await videoCommandRepository.AddAsync(request.ToVideo(fileService));

        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Video not saved !!!"))
            : BaseResult.Success();
    }
}