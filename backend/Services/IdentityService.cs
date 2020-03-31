using System;
using System.Collections.Generic;
using backend.Objects;
using backend.Repositories;
using Microsoft.Extensions.Logging;

namespace backend.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ILogger<IdentityService> _logger;

        private readonly IIdentityRepository identityRepository;

        private readonly Dictionary<IdentityToken, IdentityInformation> tokenInformation;

        private readonly IProfileRepostory profileRepostory;

        public IdentityService(ILogger<IdentityService> logger,
            IIdentityRepository identityRepository,
            IProfileRepostory profileRepostory)
        {
            _logger = logger;
            this.identityRepository = identityRepository;
            this.tokenInformation = new Dictionary<IdentityToken, IdentityInformation>();
            this.profileRepostory = profileRepostory;
        }
        
        public IdentityInformation GetIdentityForToken(IdentityToken token)
        {
            if (tokenInformation.ContainsKey(token))
            {
                return tokenInformation[token];
            }

            return null;
        }

        public bool GetIdentityToken(Credentials credentials, out IdentityToken token)
        {
            token = new IdentityToken();
            var info = identityRepository.GetForEmail(credentials.Email);
            
            if (info != null && info.PasswordHash == credentials.PasswordHash)
            {
                token = IdentityToken.New;
                tokenInformation.Add(token, info);

                return true;
            }

            return false;
        }

        public Profile GetProfileForIdentity(IdentityInformation information)
        {
            throw new NotImplementedException();
        }

        public bool RegisterNewIdentity(IdentityInformation information, Profile profile, out IdentityToken token)
        {
            token = new IdentityToken();
            if (identityRepository.GetForEmail(information.Email) == null)
            {
                if (profileRepostory.Create(ref profile))
                {
                    information.ProfileId = profile.ProfileId;
                    identityRepository.Create(information);
                    token = IdentityToken.New;
                    tokenInformation.Add(token, information);

                    return true;
                }
            }

            return false;
        }

        public bool RemoveIdentity(IdentityInformation information, IdentityToken token)
        {
            if (!tokenInformation.ContainsKey(token) ||
                tokenInformation[token].Equals(information) ||
                (DateTime.Now - token.CreatedOn).TotalMinutes > (double)token.ExpiresIn)
            {
                return false;
            }

            return identityRepository.Delete(information);
        }

        public IdentityInformation UpdateIdentity(IdentityInformation information, IdentityToken token)
        {
            throw new NotImplementedException();
        }
    }
}