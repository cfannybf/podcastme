using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Objects;
using backend.Repositories;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PodcastController : ControllerBase
    {
        private readonly ILogger<PodcastController> _logger;
        private readonly IPodcastRepository podcastRepository;

        public PodcastController(ILogger<PodcastController> logger, IPodcastRepository podcastRepository)
        {
            _logger = logger;
            this.podcastRepository = podcastRepository;
        }

        [HttpGet]
        [Route("Popular")]
        public IEnumerable<Podcast> GetPopularPodcasts()
        {
            return podcastRepository.GetPopularPodcasts();
        }

        [HttpGet]
        [Route("Me")]

        public IEnumerable<Podcast> GetMyPodcasts()
        {
            //Mocked data
            return podcastRepository.GetPodcastsForProfileId("4900f294-aeef-4902-bbaf-04f6899e1374");
        }

        [HttpGet]
        [Route("Queue")]

        public IEnumerable<Podcast> GetQueuedPodcasts()
        {
            //Mocked data
            return podcastRepository.GetPodcastsForProfileId("a5e5b880-0ca2-46c2-baf9-9aeae491d7b9");
        }
    }
}