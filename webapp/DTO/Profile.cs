using System;
using System.Text.Json.Serialization;

namespace webapp.DTO
{
    public class Profile
    {
        [JsonPropertyName("profileId")]
        public string ProfileId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("profilePhoto")]
        public string ProfilePhoto { get; set; }

        [JsonPropertyName("bio")]
        public string Bio { get; set; }

        [JsonPropertyName("joinedOn")]
        public DateTime JoinedOn { get; set; }
    }
}