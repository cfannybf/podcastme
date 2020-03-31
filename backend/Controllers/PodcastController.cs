using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Objects;
using backend.Repositories;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PodcastController : ControllerBase
    {
        private readonly ILogger<PodcastController> _logger;
        private readonly IPodcastRepository podcastRepository;
        private readonly IIdentityService identityService;

        public PodcastController(ILogger<PodcastController> logger, IPodcastRepository podcastRepository, IIdentityService identityService)
        {
            _logger = logger;
            this.podcastRepository = podcastRepository;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("Popular")]
        public IEnumerable<Podcast> GetPopularPodcasts()
        {
            return podcastRepository.GetPopularPodcasts();
        }

        [HttpGet]
        [Route("Me/{token}")]

        public IEnumerable<Podcast> GetMyPodcasts(string token)
        {
            var identity = identityService.GetIdentityForToken(token);
            if(identity != null)
            {
                return podcastRepository.GetPodcastsForProfileId(identity.ProfileId);
            }
            return null;
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