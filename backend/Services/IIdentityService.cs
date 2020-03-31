using System;
using backend.Objects;
using backend.Repositories;

namespace backend.Services
{
    public interface IIdentityService
    {
        IdentityInformation GetIdentityForToken(string token);

        bool GetIdentityToken(Credentials credentials, out IdentityToken token);

        Profile GetProfileForIdentity(IdentityInformation information);

        bool RegisterNewIdentity(IdentityInformation information, Profile profile, out IdentityToken token);

        IdentityInformation UpdateIdentity(IdentityInformation information, IdentityToken token);

        bool RemoveIdentity(IdentityInformation information, IdentityToken token);
    }
}