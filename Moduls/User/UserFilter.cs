using MixVideo.Common;

namespace MixVideo.Moduls.User;

public record UserFilter(
    string? FullName,
    int? Age,
    string? Email):BaseFilter;