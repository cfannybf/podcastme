using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace backend.Objects
{
    public class Profile
    {
        public string ProfileId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public string Bio { get; set; }
        public DateTime JoinedOn { get; set; }

        [JsonIgnore]
        public List<Podcast> Podcasts { get; set; } = new List<Podcast>();
    }
}