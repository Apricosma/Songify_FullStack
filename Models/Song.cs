
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Song title is required")]
        [StringLength(200, ErrorMessage = "Song name cannot be greater than 100 characters or less than 1", MinimumLength = 1)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Song duration is required")]
        [Range(1, 3600, ErrorMessage = "Song length cannot be more than an hour, or less than 1 second")]
        public int DurationSeconds { get; set; }

        [Required]
        [ForeignKey (nameof(Id))]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        public virtual ICollection<SongContributor> SongContributors { get; set; }

        public Song(string title, int durationSeconds, int albumId)
        {
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
        }
    }
}
