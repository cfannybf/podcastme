using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using backend.Objects;
using Microsoft.Extensions.Logging;

namespace backend.Repositories
{
    public class PodcastRepository : IPodcastRepository
    {
        private readonly ILogger<PodcastRepository> logger;
        private readonly string connectionString;

        public PodcastRepository(ILogger<PodcastRepository> logger)
        {
            this.logger = logger;
            //TODO: Config
            this.connectionString = "Data Source=localhost;Initial Catalog=podcast_me;Persist Security Info=True;"
                                        + "User ID=sa;Password=Password1";
        }

        public Podcast GetPodcast(string id)
        {
            try
            {
                var podcasts = GetPodcastsForQuery($"SELECT * FROM PodcastInfo WHERE PodcastId='{id}'");
                return podcasts.ToList().First();
            }
            catch (Exception)
            {
                logger.LogError($"Couldn't get podcast with id: {id}");
                return null;
            }            
        }

        public IEnumerable<Podcast> GetPodcastsForProfileId(string profileId)
        {
            try
            {
                var podcasts = GetPodcastsForQuery($"SELECT * FROM PodcastInfo WHERE PodcastAuthor='{profileId}'");
                return podcasts;
            }
            catch (Exception)
            {
                logger.LogError($"Couldn't get podcast for profile id: {profileId}");
                return null;
            }    
        }

        public IEnumerable<Podcast> GetPopularPodcasts()
        {
            try
            {
                //Mockup data
                var podcasts = GetPodcastsForQuery($"SELECT * FROM PodcastInfo WHERE PodcastAuthor='f4a26f8f-1320-4cb9-912a-73bc0e9bc6d6'");
                return podcasts;
            }
            catch (Exception)
            {
                logger.LogError($"Couldn't get popular podcasts");
                return null;
            }  
        }

        private IEnumerable<Podcast> GetPodcastsForQuery(string query)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();

                    var podcasts = new List<Podcast>();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var podcast = new Podcast()
                            {
                                PodcastId = reader.GetString(0),
                                Name = reader.GetString(1),
                                Author = reader.GetString(2),
                                UploadedOn = reader.GetDateTime(3),
                                Length = reader.GetString(4)
                            };

                            podcasts.Add(podcast);
                        }
                    }

                    return podcasts;
                }
            }
            catch (Exception e)
            {
                logger.LogError($"Couldn't retrieve podcasts. {e.Message}");
                throw;
            }
        }
    }
}