using Microsoft.EntityFrameworkCore;

namespace MixVideo.Common.Data;

public sealed class AppCommandDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);