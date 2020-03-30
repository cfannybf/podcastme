using backend.Objects;

namespace backend.Repositories
{
    public interface IPodcastRepository
    {
        Podcast GetPodcast(string id);
        Podcast GetPodcastsForProfileId(string profileId);
        Podcast GetPopularPodcasts();
    }
}