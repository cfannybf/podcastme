using System;

namespace backend.Objects
{
    public class Podcast
    {
        public string PodcastId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime UploadedOn { get; set; }
        public string Length { get; set; }
    }
}