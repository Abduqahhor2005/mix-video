using MixVideo.Common.BaseRepository.BaseQueryGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.User.Repository.QueryRepository;

public class UserQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<User>(context),IUserQueryRepository;