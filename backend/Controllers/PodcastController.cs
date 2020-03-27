using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Objects;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PodcastController : ControllerBase
    {
        private readonly ILogger<PodcastController> _logger;

        public PodcastController(ILogger<PodcastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Podcast> Get()
        {
            var popularPodcasts = new List<Podcast>()
            {
                MockupPodcast("Something 1", "Someone", 3),
                MockupPodcast("Something 2", "Someone", 2),
                MockupPodcast("Something 3", "Someone", 1)
            };

            return popularPodcasts;
        }

        private Podcast MockupPodcast(string name, string author, int days)
        {
            var date = DateTime.Now;
            date = date.AddDays(-1 * days);

            var length = TimeSpan.FromHours(1);
            length = length.Add(TimeSpan.FromMinutes(new Random().Next(0, 59)));
            length = length.Add(TimeSpan.FromSeconds(new Random().Next(0, 59)));

            return new Podcast
            {
                Name = name,
                Author = author,
                UploadedOn = date,
                Length = length
            };
        }
    }
}