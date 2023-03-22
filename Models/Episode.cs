using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Episode : MediaItem
    {
        [Required]
        [ForeignKey(nameof(Id))]
        public int PodcastId { get; set; }

        [Required]
        public DateTime AirDate { get; set; }

        [Required]
        public virtual Podcast Podcast { get; set; }

        public Episode() : base()
        {
        }

        public Episode(string title, int durationSeconds, int podcastId) : base(title, durationSeconds)
        {
            PodcastId = podcastId;
            AirDate = DateTime.UtcNow;
        }
    }
}
