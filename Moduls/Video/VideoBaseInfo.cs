namespace MixVideo.Moduls.Video;

public readonly record struct VideoBaseInfo(
    string Title,
    bool IsPaid,
    string Description,
    decimal? Price,
    IFormFile? File);