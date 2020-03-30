using System;
using System.Text.Json.Serialization;

namespace webapp.DTO
{
    public class Podcast
    {
        [JsonPropertyName("podcastId")]
        public string PodcastId { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("uploadedOn")]
        public DateTime UploadedOn { get; set; }

        [JsonPropertyName("length")]
        public string Length { get; set; }
    }
}