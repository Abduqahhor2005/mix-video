namespace MixVideo.Moduls.User;

public readonly record struct UserBaseInfo(
    string FullName,
    int Age,
    string Email);