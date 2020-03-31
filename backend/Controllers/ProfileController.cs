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
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly IProfileRepostory profileRepository;
        private readonly IIdentityService identityService;

        public ProfileController(ILogger<ProfileController> logger, IProfileRepostory repository, IIdentityService identityService)
        {
            _logger = logger;
            profileRepository = repository;
            this.identityService = identityService;
        }

        [HttpGet]
        [Route("Me/{token}")]
        public Profile GetMyProfile(string token)
        {
            var identity = identityService.GetIdentityForToken(token);
            if(identity != null)
            {
                return profileRepository.Get(identity.ProfileId);
            }
            return null;
        }
    }
}