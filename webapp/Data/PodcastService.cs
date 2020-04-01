using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace webapp.Data
{
    public class PodcastService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly ILogger<PodcastService> logger;
        private readonly SessionState state;

        public PodcastService(ILogger<PodcastService> logger, SessionState state)
        {
            this.logger = logger;
            this.state = state;
        }

        public async Task<Podcast[]> GetPopularPodcasts()
        {
            //TODO: Config this
            return await GetPodcastsFromEndpoint("http://127.0.0.1:6001/podcast/popular");
        }

        public async Task<Podcast[]> GetMyPodcasts()
        {
            var token = state.Storage["token"];
            return await GetPodcastsFromEndpoint($"http://127.0.0.1:6001/podcast/me/{token}");
        }

        public async Task<Podcast[]> GetQueuedPodcasts()
        {
            //TODO: Session ID
            return await GetPodcastsFromEndpoint("http://127.0.0.1:6001/podcast/queue");
        }

        private async Task<Podcast[]> GetPodcastsFromEndpoint(string endpoint)
        {
            var streamTask = client.GetStreamAsync(endpoint);
            var podcasts = await JsonSerializer.DeserializeAsync<List<DTO.Podcast>>(await streamTask);

            try
            {
                var retval = podcasts.Select(x => new Podcast()
                {
                    PodcastId = x.PodcastId,
                    Name = x.Name,
                    Author = x.Author,
                    UploadedOn = x.UploadedOn,
                    Length = TimeSpan.Parse(x.Length)
                });

                return retval.ToArray();
            }
            catch(FormatException)
            {
                logger.LogError($"Invalid timespan format.");
            }
            catch(Exception)
            {
                logger.LogError($"Unable to retrieve podcasts.");
            }

            return new Podcast[] {};
        }
    }
}
