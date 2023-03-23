using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Contributor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Id))]
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int? PodcastId { get; set; }
        public Podcast Podcast { get; set; }

        public int? SongId { get; set; }
        public Song Song { get; set; }


        public Contributor()
        {

        }

        public Contributor(int artistId, int? songId, int? podcastId)
        {
            ArtistId = artistId;
            SongId = songId;
            PodcastId = podcastId;
        }
    }
}
