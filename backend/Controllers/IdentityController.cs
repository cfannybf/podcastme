using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using backend.Objects;
using backend.Services;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly ILogger<IdentityController> _logger;

        private readonly IIdentityService identityService;

        public IdentityController(ILogger<IdentityController> logger, IIdentityService identityService)
        {
            _logger = logger;
            this.identityService = identityService;
        }

        [HttpPost]
        [Route("Identity/Authorize")]
        public IActionResult Authorize(Credentials credentials)
        {
            if (identityService.GetIdentityToken(credentials, out var identityToken))
            {
                return Ok(identityToken);
            }

            return Unauthorized();
        }

        [HttpPost]
        [Route("Identity/Create")]
        public IActionResult Create(IdentityInformation information, Profile profile)
        {
            if (identityService.RegisterNewIdentity(information, profile, out var identityToken))
            {
                return Ok(identityToken);
            }

            return Unauthorized();
        }

        [HttpPut]
        [Route("Identity/Update")]
        public IActionResult Update(Credentials credentials)
        {
            return Unauthorized();
        }

        [HttpDelete]
        [Route("Identity/Delete")]
        public IActionResult Delete(Credentials credentials)
        {
            return Unauthorized();
        }
    }
}