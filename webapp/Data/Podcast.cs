using System;

namespace webapp.Data
{
    public class Podcast
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime UploadedOn { get; set; }
        public TimeSpan Length { get; set; }

        public static Podcast MockupPodcast(string name, string author, int days)
        {
            var date = DateTime.Now;
            date = date.AddDays(-1 * days);

            var length = TimeSpan.FromHours(1);
            length = length.Add(TimeSpan.FromMinutes(new Random().Next(0, 59)));
            length = length.Add(TimeSpan.FromSeconds(new Random().Next(0, 59)));

            return new Podcast
            {
                Name = name,
                Author = author,
                UploadedOn = date,
                Length = length
            };
        }
    }
}