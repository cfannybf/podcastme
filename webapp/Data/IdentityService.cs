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
using System.Security.Cryptography;

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
                var url = "http://127.0.0.1:6001/Identity/Identity/Authorize";
                return await AuthorizationCall(data, url);
            }
            catch(Exception e)
            {
                logger.LogError($"Error during authentication. {e.Message}");
            }

            return false;
        }

        public async Task<bool> CreateAccountAsync(DTO.Profile profile, string email, string passwordHash)
        {
            var content = new CreateIdentity()
            {
                profile = profile,
                Identity = new IdentityInformation()
                {
                    Email = email,
                    PasswordHash = passwordHash
                }
            };

            var json = JsonConvert.SerializeObject(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var url = "http://127.0.0.1:6001/Identity/Identity/Create";
                return await AuthorizationCall(data, url);
            }
            catch (Exception e)
            {
                logger.LogError($"Unable to register entity with email {email}. {e.Message}");
            }

            return false;
        }

        public static string HashPassword(string plaintext, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, plaintext);
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }

        private async Task<bool> AuthorizationCall(StringContent data, string url)
        {
            var response = await client.PostAsync(url, data);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();
                var token = JsonConvert.DeserializeObject<IdentityToken>(result);
                state.Storage["token"] = token.Token;
                return true;
            }
            return false;
        }
    }
}
