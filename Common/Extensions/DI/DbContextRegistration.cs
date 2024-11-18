using System.Reflection;
using FluentValidation;
using MixVideo.Common.Data;
using Microsoft.EntityFrameworkCore;

namespace MixVideo.Common.Extensions.DI;

public static class DbContextRegistration
{
    public static WebApplicationBuilder AddDbContext(this WebApplicationBuilder builder)
    {
        
        builder.Services.AddDbContext<BaseDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));
        
        builder.Services.AddDbContext<AppCommandDbContext>(x =>
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .LogTo(Console.WriteLine));

        builder.Services.AddDbContext<AppQueryDbContext>(x =>
        {
            x.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(Console.WriteLine);
        });
        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return builder;
    }
}