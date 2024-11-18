using MixVideo.Common.BaseRepository.BaseQueryGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Comment.Repository.QueryRepository;

public class CommentQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Comment>(context),ICommentQueryRepository;