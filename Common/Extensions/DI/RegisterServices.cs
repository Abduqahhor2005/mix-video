using System.Reflection;
using MixVideo.Common.BaseRepository.BaseCommandGenericRepository;
using MixVideo.Common.BaseRepository.BaseQueryGenericRepository;
using MixVideo.Moduls.Comment.Repository.CommandRepository;
using MixVideo.Moduls.Comment.Repository.QueryRepository;
using MixVideo.Moduls.Payment.Repository.CommandRepository;
using MixVideo.Moduls.Payment.Repository.QueryRepository;
using MixVideo.Moduls.User.Repository.CommandRepository;
using MixVideo.Moduls.User.Repository.QueryRepository;
using MixVideo.Moduls.Video.FileService;
using MixVideo.Moduls.Video.Repository.CommandRepository;
using MixVideo.Moduls.Video.Repository.QueryRepository;
using MixVideo.Moduls.Viewer.Repository.CommandRepository;
using MixVideo.Moduls.Viewer.Repository.QueryRepository;

namespace MixVideo.Common.Extensions.DI;

public static class RegisterServices
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped(typeof(ICommandGenericRepository<>), typeof(CommandGenericRepository<>));
        services.AddScoped<ICommentCommandRepository, CommentCommandRepository>();
        services.AddScoped<IPaymentCommandRepository, PaymentCommandRepository>();
        services.AddScoped<IUserCommandRepository, UserCommandRepository>();
        services.AddScoped<IVideoCommandRepository, VideoCommandRepository>();
        services.AddScoped<IViewerCommandRepository, ViewerCommandRepository>();
        services.AddScoped(typeof(IQueryGenericRepository<>), typeof(QueryGenericRepository<>));
        services.AddScoped<ICommentQueryRepository, CommentQueryRepository>();
        services.AddScoped<IPaymentQueryRepository, PaymentQueryRepository>();
        services.AddScoped<IUserQueryRepository, UserQueryRepository>();
        services.AddScoped<IVideoQueryRepository, VideoQueryRepository>();
        services.AddScoped<IViewerQueryRepository, ViewerQueryRepository>();
        services.AddSingleton<IFileService, FileService>();
        return services;
    }
}