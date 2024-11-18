using MixVideo.Common.BaseRepository.BaseQueryGenericRepository;
using MixVideo.Common.Data;

namespace MixVideo.Moduls.Viewer.Repository.QueryRepository;

public class ViewerQueryRepository(AppQueryDbContext context)
    :QueryGenericRepository<Viewer>(context),IViewerQueryRepository;