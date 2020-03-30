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

        public PodcastService(ILogger<PodcastService> logger)
        {
            this.logger = logger;
        }

        public async Task<Podcast[]> GetPodcasts()
        {
            var streamTask = client.GetStreamAsync("http://localhost:6001/podcast");
            var podcasts = await JsonSerializer.DeserializeAsync<List<DTO.Podcast>>(await streamTask);

            try
            {
                var retval = podcasts.Select(x => new Podcast()
                {
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
