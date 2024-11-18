using MediatR;
using MixVideo.Common.PatternResult;
using MixVideo.Moduls.Video.Constants;
using MixVideo.Moduls.Video.FileService;
using MixVideo.Moduls.Video.Repository.CommandRepository;

namespace MixVideo.Moduls.Video.Commands.VideoCommandHandler;

public class DeleteVideoHandler(IFileService fileService,IVideoCommandRepository videoCommandRepository)
    :IRequestHandler<DeleteVideoRequest,BaseResult>
{
    public async Task<BaseResult> Handle(DeleteVideoRequest request, CancellationToken cancellationToken)
    {
        IEnumerable<Video?> existingVideos = await videoCommandRepository.FindAsync(x =>
            x.Id == request.Id);    
        Video? existing = existingVideos.FirstOrDefault();
        if (existing is null) return BaseResult.Failure(Error.None());;

        int res = await videoCommandRepository.UpdateAsync(existing.ToDeletedVideo());

        fileService.DeleteFile(existing.Title, MediaFolders.Videos);
        return res is 0
            ? BaseResult.Failure(Error.InternalServerError("Video not deleted !!!"))
            : BaseResult.Success();
    }
}