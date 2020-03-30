using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace webapp.Data
{
    public class PodcastService
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<Podcast[]> GetPodcasts()
        {
            var streamTask = client.GetStreamAsync("http://localhost:6001/podcast");
            var podcasts = await JsonSerializer.DeserializeAsync<List<Podcast>>(await streamTask);
            
            return podcasts.ToArray();
        }
    }
}
