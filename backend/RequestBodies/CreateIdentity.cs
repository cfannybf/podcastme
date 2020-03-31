using System;
using backend.Objects;

namespace backend.RequestBodies
{
    public class CreateIdentity
    {
        public Profile profile { get; set; }
        public IdentityInformation Identity { get; set; }
    }
}