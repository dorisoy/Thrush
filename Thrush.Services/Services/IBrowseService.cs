using System.Collections.Generic;
using System.Threading.Tasks;
using MediaManager.Library;

namespace Thrush.Services.Services
{
    public interface IBrowseService
    {
        IList<IMediaItem> RecentMedia { get; set; }

        void AddToRecentMedia(IMediaItem mediaItem);
    }
}
