using MixVideo.Common.BaseRepository.BaseCommandGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Viewer.Repository.CommandRepository;

public class ViewerCommandRepository(AppCommandDbContext context)
    :CommandGenericRepository<Viewer>(context),IViewerCommandRepository;