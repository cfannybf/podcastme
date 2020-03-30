using System;
using Microsoft.Data.SqlClient;
using backend.Objects;

namespace backend.Repositories
{
    public class PodcastRepository : IPodcastRepository
    {
        public Podcast GetPodcast(string id)
        {
            throw new NotImplementedException();
        }

        public Podcast GetPodcastsForProfileId(string profileId)
        {
            throw new NotImplementedException();
        }

        public Podcast GetPopularPodcasts()
        {
            throw new NotImplementedException();
        }
    }
}