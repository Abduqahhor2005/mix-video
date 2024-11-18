using Microsoft.EntityFrameworkCore;

namespace MixVideo.Common.Data;

public sealed class AppQueryDbContext(DbContextOptions<BaseDbContext> options) : BaseDbContext(options);