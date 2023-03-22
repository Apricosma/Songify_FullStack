
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Song : MediaItem
    {
        [Required]
        [ForeignKey (nameof(Id))]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        public virtual ICollection<Contributor> Contributors { get; set; }

        public Song() : base() 
        { 

        }

        public Song(string title, int durationSeconds, int albumId) : base(title, durationSeconds)
        {
            AlbumId = albumId;
        }
    }
}
