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
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileRepostory profileRepository;

        public ProfileController(ILogger<ProfileController> logger, IProfileRepostory repository)
        {
            _logger = logger;
            profileRepository = repository;
        }

        [HttpGet]
        [Route("Me")]
        public Profile GetMyProfile()
        {
            //Mockup data
            var profileId = "4900f294-aeef-4902-bbaf-04f6899e1374";
            var profile = profileRepository.Get(profileId);

            return profile;
        }
    }
}