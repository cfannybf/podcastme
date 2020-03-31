using System;

namespace backend.Objects
{
    public class IdentityInformation
    {
        public string ProfileId { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is IdentityInformation))
            {
                return false;
            }

            return (this.ProfileId == ((IdentityInformation)obj).ProfileId &&
                    this.Email == ((IdentityInformation)obj).Email &&
                    this.PasswordHash == ((IdentityInformation)obj).PasswordHash);
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = (hash * 13) + (!Object.ReferenceEquals(null, ProfileId) ? ProfileId.GetHashCode() : 0);
            hash = (hash * 13) + (!Object.ReferenceEquals(null, Email) ? Email.GetHashCode() : 0);
            hash = (hash * 13) + (!Object.ReferenceEquals(null, PasswordHash) ? PasswordHash.GetHashCode() : 0);
            return hash;
        }
    }
}