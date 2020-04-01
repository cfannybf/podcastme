using System;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using webapp.DTO;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace webapp.Data
{
    public class IdentityService
    {
        private readonly ILogger<IdentityService> logger;
        private readonly HttpClient client = new HttpClient();
        private readonly SessionState state;

        public IdentityService(ILogger<IdentityService> logger, SessionState state)
        {
            this.logger = logger;
            this.state = state;
        }

        public async Task<bool> AuthenticateAsync(string email, string passwordHash)
        {
            var content = new AuthenticationRequest()
            {
                Email = email,
                PasswordHash = passwordHash
            };

            var json = JsonConvert.SerializeObject(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await client.PostAsync("http://127.0.0.1:6001/Identity/Identity/Authorize", data);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<IdentityToken>(result);
                    state.Storage["token"] = token.Token;
                    return true;
                }
            }
            catch(Exception e)
            {
                logger.LogError($"Error during authentication. {e.Message}");
            }

            return false;
        }
    }
}
