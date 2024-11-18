using MixVideo.Common.BaseRepository.BaseCommandGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.User.Repository.CommandRepository;

public class UserCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<User>(context),IUserCommandRepository;