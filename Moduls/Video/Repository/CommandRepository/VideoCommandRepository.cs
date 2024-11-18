using MixVideo.Common.BaseRepository.BaseCommandGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Video.Repository.CommandRepository;

public class VideoCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Video>(context),IVideoCommandRepository;