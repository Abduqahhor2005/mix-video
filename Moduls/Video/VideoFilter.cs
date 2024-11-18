using MixVideo.Common;

namespace MixVideo.Moduls.Video;

public record VideoFilter(
    string? Title,
    bool? IsPaid,
    string? Description,
    decimal? Price):BaseFilter;