using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Songify_FullStack.Models
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Playlist name cannot be greater than 30 characters, or less than 2", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int UserId { get; set; }

        public ICollection<PlaylistSong> PlaylistSongs { get; set; } = new List<PlaylistSong>();
        public User? User { get; set; }

        public Playlist()
        {

        }

        public Playlist(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }
    }
}
