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
    public class ProfileController : ControllerBase
    {
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(ILogger<ProfileController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Me")]
        public Profile GetMyProfile()
        {
            //Mockup data
            var profile = new Profile();
            profile.Name = "Someone";
            profile.Email = "someone@example.com";
            profile.ProfilePhoto = "avatar.jpg";
            profile.Bio = "This is my sample bio.";
            profile.JoinedOn = DateTime.Now.AddDays(-100);

            return profile;
        }
    }
}