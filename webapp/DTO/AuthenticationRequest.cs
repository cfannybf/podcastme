using System;

namespace webapp.DTO
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}