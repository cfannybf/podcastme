using System;
using webapp.DTO;

namespace webapp.DTO
{
    public class CreateIdentity
    {
        public Profile profile { get; set; }
        public IdentityInformation Identity { get; set; }
    }
}