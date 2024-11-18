using Microsoft.EntityFrameworkCore;
using MixVideo.Common.Extensions;
using MixVideo.Moduls.Comment;
using MixVideo.Moduls.Payment;
using MixVideo.Moduls.User;
using MixVideo.Moduls.Video;
using MixVideo.Moduls.Viewer;

namespace MixVideo.Common.Data;

public  class BaseDbContext(DbContextOptions<BaseDbContext> options) : DbContext(options)
{ 
    public DbSet<User> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Viewer> Viewers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
        modelBuilder.FilterSoftDeletedProperties();
        base.OnModelCreating(modelBuilder);
    }
}