using MixVideo.Common;

namespace MixVideo.Moduls.Viewer;

public record ViewerFilter(
    DateTime? ViewDate,
    bool? IsPurchased,
    int? UserId, 
    int? VideoId):BaseFilter;