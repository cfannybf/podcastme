using System;

namespace webapp.DTO
{
    public class IdentityInformation
    {
        public string ProfileId { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}