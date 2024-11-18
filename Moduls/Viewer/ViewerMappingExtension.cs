using MixVideo.Moduls.Viewer.Commands;
using MixVideo.Moduls.Viewer.Queries;

namespace MixVideo.Moduls.Viewer;

public static class ViewerMappingExtension
{
    public static GetViewerViewModel ToReadInfo(this Viewer viewer)
    {
        return new()
        {
            Id = viewer.Id,
            ViewerBaseInfo = new()
            {
                ViewDate = viewer.ViewDate,
                IsPurchased = viewer.IsPurchased,
                UserId = viewer.UserId,
                VideoId = viewer.VideoId
            }
        };
    }
    
    public static GetViewerDetailViewModel ToReadDetailInfo(this Viewer viewer)
    {
        return new()
        {
            Id = viewer.Id,
            ViewerBaseInfo = new()
            {
                ViewDate = viewer.ViewDate,
                IsPurchased = viewer.IsPurchased,
                UserId = viewer.UserId,
                VideoId = viewer.VideoId
            }
        };
    }

    public static Viewer ToViewer(this CreateViewerRequest request)
    {
        return new()
        {
            ViewDate = request.ViewerBaseInfo.ViewDate,
            IsPurchased = request.ViewerBaseInfo.IsPurchased,
            UserId = request.ViewerBaseInfo.UserId,
            VideoId = request.ViewerBaseInfo.VideoId
        };
    }

    public static Viewer ToUpdatedViewer(this Viewer viewer, UpdateViewerRequest request)
    {
        viewer.Version++;
        viewer.UpdatedAt = DateTime.UtcNow;
        viewer.ViewDate = request.ViewerBaseInfo.ViewDate;
        viewer.IsPurchased = request.ViewerBaseInfo.IsPurchased;
        viewer.UserId = request.ViewerBaseInfo.UserId;
        viewer.VideoId = request.ViewerBaseInfo.VideoId;
        return viewer;
    }

    public static Viewer ToDeletedViewer(this Viewer viewer)
    {
        viewer.IsDeleted = true;
        viewer.DeletedAt = DateTime.UtcNow;
        viewer.UpdatedAt = DateTime.UtcNow;
        viewer.Version++;
        return viewer;
    }
}