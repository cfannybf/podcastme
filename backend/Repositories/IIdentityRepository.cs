using System;
using backend.Objects;

namespace backend.Repositories
{
    public interface IIdentityRepository
    {
        IdentityInformation GetForEmail(string email);

        IdentityInformation Update(IdentityInformation identity);
        
        bool Create(IdentityInformation identity);

        bool Delete(IdentityInformation identity);
    }
}