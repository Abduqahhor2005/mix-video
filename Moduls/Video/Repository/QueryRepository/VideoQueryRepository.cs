using MixVideo.Common.BaseRepository.BaseQueryGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Video.Repository.QueryRepository;

public class VideoQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Video>(context),IVideoQueryRepository;