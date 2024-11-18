namespace MixVideo.Moduls.Viewer;

public readonly record struct ViewerBaseInfo(
    DateTime ViewDate,
    bool IsPurchased,
    int UserId, 
    int VideoId);