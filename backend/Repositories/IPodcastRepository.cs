using System.Collections.Generic;
using backend.Objects;

namespace backend.Repositories
{
    public interface IPodcastRepository
    {
        Podcast GetPodcast(string id);
        IEnumerable<Podcast> GetPodcastsForProfileId(string profileId);
        IEnumerable<Podcast> GetPopularPodcasts();
    }
}