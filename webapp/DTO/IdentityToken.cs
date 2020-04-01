using System;

namespace webapp.DTO
{
    public class IdentityToken
    {
        public string Token { get; set; }

        public int ExpiresIn { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}