using System;

namespace backend.Objects
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime UploadedOn { get; set; }
        public TimeSpan Length { get; set; }
    }
}