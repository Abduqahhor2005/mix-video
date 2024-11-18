using MixVideo.Common.BaseRepository.BaseCommandGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Comment.Repository.CommandRepository;

public class CommentCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Comment>(context),ICommentCommandRepository;