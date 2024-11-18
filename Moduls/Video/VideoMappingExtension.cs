using MixVideo.Moduls.Video.Commands;
using MixVideo.Moduls.Video.Constants;
using MixVideo.Moduls.Video.FileService;
using MixVideo.Moduls.Video.Queries;

namespace MixVideo.Moduls.Video;

public static class VideoMappingExtension
{
    public static GetVideoViewModel ToReadInfo(this Video video)
    {
        return new()
        {
            Id = video.Id,
            VideoBaseInfo = new()
            {
                Title = video.Title,
                IsPaid = video.IsPaid,
                Description = video.Description,
                Price = video.Price
            }
        };
    }
    
    public static GetVideoDetailViewModel ToReadDetailInfo(this Video video)
    {
        return new()
        {
            Id = video.Id,
            VideoBaseInfo = new()
            {
                Title = video.Title,
                IsPaid = video.IsPaid,
                Description = video.Description,
                Price = video.Price
            }
        };
    }

    public static Video ToVideo(this CreateVideoRequest request,IFileService fileService)
    {
        return new()
        {
            Title = fileService.CreateFile(request.VideoBaseInfo.File!,MediaFolders.Videos),
            IsPaid = request.VideoBaseInfo.IsPaid,
            Description = request.VideoBaseInfo.Description,
            Price = request.VideoBaseInfo.Price
        };
    }

    public static Video ToUpdatedVideo(this Video video, UpdateVideoRequest request,IFileService fileService)
    {
        video.Version++;
        video.UpdatedAt = DateTime.UtcNow;
        video.Title = fileService.CreateFile(request.VideoBaseInfo.File!, MediaFolders.Videos);
        video.IsPaid = request.VideoBaseInfo.IsPaid;
        video.Description = request.VideoBaseInfo.Description;
        video.Price = request.VideoBaseInfo.Price;
        return video;
    }

    public static Video ToDeletedVideo(this Video video)
    {
        video.IsDeleted = true;
        video.DeletedAt = DateTime.UtcNow;
        video.UpdatedAt = DateTime.UtcNow;
        video.Version++;
        return video;
    }
}