using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace webapp.Data
{
    public class ProfileService
    {
        private readonly HttpClient client = new HttpClient();
        private readonly ILogger<ProfileService> logger;
        private readonly SessionState state;

        public ProfileService(ILogger<ProfileService> logger, SessionState state)
        {
            this.logger = logger;
            this.state = state;
        }

        public async Task<Profile> GetMyProfile()
        {
            var token = state.Storage["token"];
            var streamTask = client.GetStreamAsync($"http://127.0.0.1:6001/profile/me/{token}");
            var profile = await JsonSerializer.DeserializeAsync<DTO.Profile>(await streamTask);

            try
            {
                var retval = new Profile()
                {
                    ProfileId = profile.ProfileId,
                    Name = profile.Name,
                    Email = profile.Email,
                    ProfilePhoto = profile.ProfilePhoto,
                    Bio = profile.Bio,
                    JoinedOn = profile.JoinedOn
                };

                return retval;
            }
            catch(Exception)
            {
                logger.LogError($"Unable to retrieve profile.");
            }

            return new Profile();
        }
    }
}