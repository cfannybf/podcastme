using System;
using System.Collections.Generic;

namespace webapp.Data
{
    public class Profile
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public string Bio { get; set; }
        public DateTime JoinedOn { get; set; }
        public List<Podcast> Podcasts { get; set; }
    }
}